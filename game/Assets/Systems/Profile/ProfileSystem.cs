using System.Collections.Generic;
using System.Linq;
using Assets.Utils;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Profile.Events;
using Systems.Profile.ScriptableObjects;
using Systems.Time.Events;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.Profile
{
    [GameSystem]
    public class ProfileSystem : GameSystem<ProfileConfigComponent, RatingButtonComponent>
    {
        private Queue<DisplayProfile> _profiles;
        private ProfileConfigComponent _profileConfig;
        private ProfileText[] _randomTexts;
        private int _randomTextIndex = 0;

        public ProfileSystem()
        {
            _randomTexts = ScriptableObjectSearcher.GetAllProfileTexts();
        }

        public override void Register(ProfileConfigComponent component)
        {
            _profileConfig = component;

            var randomImages = ScriptableObjectSearcher.AllProfileImages()
                .Where(image => !image.shouldNotBeRandom);

            var randomProfiles = randomImages
                .Select(GenerateProfile);

            var allProfiles = randomProfiles
                .Concat(ScriptableObjectSearcher.GetAllInstances<ProfileSo>())
                .ToList().Randomize();

            _profiles = new Queue<DisplayProfile>(allProfiles
                .Select(profile => new DisplayProfile {Profile = profile, Rating = Rating.None}));

            component.activeProfile.Value = _profiles.Peek();

            MessageBroker.Default.Publish(new ProfileQueueFilledEvent {queue = _profiles});

            MessageBroker.Default.Receive<TickEvent>().Subscribe(_ => ShowNext(component)).AddTo(component);
        }

        public override void Register(RatingButtonComponent component)
        {
            component.Command.Subscribe(RateAndShowNext).AddTo(component);

            MessageBroker.Default.Receive<SetNopeStateEvent>().Subscribe(msg =>
            {
                component.likeStamp.SetActive(false);
                component.nopeStamp.SetActive(msg.profile.Rating == Rating.Dislike);
            }).AddTo(component);
        }

        private void ShowNext(ProfileConfigComponent profileConfigComponent)
        {
            if (profileConfigComponent.debugSwitchProfiles || !_profiles.Any()) return;

            var rating = profileConfigComponent.activeProfile.Value.Rating;
            SwitchToNextProfile(rating);
        }

        private void RateAndShowNext(RatingButtonComponent ratingComponent)
        {
            if (_profileConfig == null || _profiles == null) return;
            _profileConfig.activeProfile.Value.Rating = ratingComponent.rating;

            if (ratingComponent.rating == Rating.Like)
            {
                ratingComponent.likeStamp.SetActive(true);
                ratingComponent.nopeStamp.SetActive(false);
            }
            else if (ratingComponent.rating == Rating.Dislike)
            {
                ratingComponent.likeStamp.SetActive(false);
                ratingComponent.nopeStamp.SetActive(true);
            }

            if (!_profileConfig.debugSwitchProfiles || !_profiles.Any()) return;
            SwitchToNextProfile(ratingComponent.rating);
        }


        private void SwitchToNextProfile(Rating rating)
        {
            if (rating is Rating.Dislike or Rating.None)
            {
                _profiles.Enqueue(_profiles.Dequeue());
            }
            else
            {
                var profile = _profiles.Dequeue();
                MessageBroker.Default
                    .Publish(new LikedProfileEvent
                    {
                        likedProfile = profile
                    });
            }

            if (_profiles.Any())
            {
                _profileConfig.activeProfile.Value = _profiles.Peek();
                MessageBroker.Default.Publish(new SetNopeStateEvent {profile = _profileConfig.activeProfile.Value});
            }
            else
            {
                // ToDo Forever Alone Image
            }
        }

        private ProfileSo GenerateProfile(ProfileImage profileImage)
        {
            var profile = ScriptableObject.CreateInstance<ProfileSo>();
            profile.profileImage = profileImage;
            profile.name = AmericanNameGenerator.GenerateName(AmericanNameGenerator.Gender.Neutral);
            profile.age = profileImage.ageRange.x + profileImage.ageRange.y > 0
                ? Random.Range(profileImage.ageRange.x, profileImage.ageRange.y)
                : Random.Range(18, 99);
            profile.distance = Random.Range(0f, 250f);

            var allTraits = ScriptableObjectSearcher.GetAllPersonalityTraits();

            var randomProfileTextTemplate = GetRandomTextTemplate();
            var traits =
                profileImage.traits.Concat(
                        randomProfileTextTemplate.Categories
                            .Select(category => allTraits
                                .Where(t => t.category == category)
                                .ToArray()
                                .RandomElement())
                    )
                    .Where(x => x != null)
                    .ToArray();

            profile.text = randomProfileTextTemplate.CreateText(traits, profile.name);
            profile.traits = traits;

            return profile;
        }

        private ProfileText GetRandomTextTemplate()
        {
            try
            {
                if (_randomTextIndex == 0) _randomTexts = _randomTexts.Randomize().ToArray();

                return _randomTexts[_randomTextIndex];
            }
            finally
            {
                _randomTextIndex = (_randomTextIndex + 1) % _randomTexts.Length;
            }
        }
    }
}