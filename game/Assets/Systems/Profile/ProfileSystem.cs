using System.Collections.Generic;
using System.Linq;
using Assets.Utils;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Profile.ScriptableObjects;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.Profile
{
    [GameSystem]
    public class ProfileSystem : GameSystem<ProfileConfigComponent, RatingButtonComponent>
    {
        public ReactiveProperty<DisplayProfile> ActiveProfile { get; } = new();
        private Queue<DisplayProfile> _profiles;

        public override void Register(ProfileConfigComponent component)
        {
            var profileSprites = new Queue<Sprite>(component.profileSprites.ToList().Randomize());

            var profiles = Enumerable.Range(0, component.randomProfiles)
                .Select(_ =>
                {
                    var profile = GenerateProfile();
                    profile.avatar = profileSprites.Peek();
                    profileSprites.Enqueue(profileSprites.Dequeue());
                    return profile;
                })
                .Concat(ScriptableObjectSearcher.GetAllInstances<ProfileSo>())
                .Select(p => new DisplayProfile { Profile = p, Rating = null })
                .ToList();

            profiles = profiles.Randomize();

            _profiles = new Queue<DisplayProfile>(profiles);
            ActiveProfile.Value = _profiles.Peek();
        }

        public override void Register(RatingButtonComponent component)
        {
            component.Command.Subscribe(RateAndShowNext).AddTo(component);
        }

        public void RateAndShowNext(Rating rating)
        {
            ActiveProfile.Value.Rating = rating;
            _profiles.Enqueue(_profiles.Dequeue());
            ActiveProfile.Value = _profiles.Peek();
        }

        public ProfileSo GenerateProfile()
        {
            var profile = ScriptableObject.CreateInstance<ProfileSo>();
            profile.name = AmericanNameGenerator.GenerateName(AmericanNameGenerator.Gender.Neutral);
            profile.age = Random.Range(18, 99);
            profile.distance = Random.Range(0f, 1000f);

            
            var allTraits = ScriptableObjectSearcher.GetAllPersonalityTraits()
                .ToArray();
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