using System.Collections.Generic;
using System.Linq;
using Assets.Utils;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Profile.Events;
using Systems.Profile.ScriptableObjects;
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
                .Select(profile => new DisplayProfile {Profile = profile, Rating = null}));

            component.activeProfile.Value = _profiles.Peek();

            MessageBroker.Default.Publish(new ProfileQueueFilledEvent {queue = _profiles});
        }

        public override void Register(RatingButtonComponent component)
        {
            component.Command.Subscribe(RateAndShowNext).AddTo(component);
        }

        public void RateAndShowNext(Rating rating)
        {
            if (_profileConfig == null || _profiles == null) return;
            _profileConfig.activeProfile.Value.Rating = rating;
            if (rating == Rating.Dislike)
            {
                _profiles.Enqueue(_profiles.Dequeue());
            }
            else
            {
                var profile = _profiles.Dequeue();
                MessageBroker.Default
                    .Publish(new ActiveProfileChangedEvent {lastProfile = profile});
            }

            _profileConfig.activeProfile.Value = _profiles.Peek();
        }

        public ProfileSo GenerateProfile(ProfileImage profileImage)
        {
            var profile = ScriptableObject.CreateInstance<ProfileSo>();
            profile.profileImage = profileImage;
            profile.name = AmericanNameGenerator.GenerateName(AmericanNameGenerator.Gender.Neutral);
            profile.age = Random.Range(18, 99);
            profile.distance = Random.Range(0f, 1000f);

            var allTraits = ScriptableObjectSearcher.GetAllPersonalityTraits();
            var allTexts = ScriptableObjectSearcher.GetAllProfileTexts();

            var randomProfileTextTemplate = allTexts.RandomElement();
            var traits = randomProfileTextTemplate.Categories
                .Select(category => allTraits
                    .Where(t => t.category == category)
                    .ToArray()
                    .RandomElement())
                .ToArray();

            profile.text = randomProfileTextTemplate.CreateText(traits, profile.name);
            profile.traits = traits;

            return profile;
        }
    }
}