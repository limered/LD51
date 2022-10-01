using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Utils;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Properties;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Systems.Profile
{
    [GameSystem]
    public class ProfileSystem : GameSystem<ProfileConfigComponent, RatingButtonComponent>
    {
        public ReactiveProperty<DisplayProfile> ActiveProfile { get; } = new();
        private Queue<DisplayProfile> _profiles;

        public override void Register(ProfileConfigComponent displaySystem)
        {
            var profiles = Enumerable.Range(0, displaySystem.randomProfiles)
                .Select(_ => GenerateProfile())
                .Concat(ScriptableObjectSearcher.GetAllInstances<Profile>())
                .Select(p => new DisplayProfile { Profile = p, Rating = null })
                .ToList();

            profiles = profiles.Randomize();
            
            _profiles = new Queue<DisplayProfile>(profiles);
            ActiveProfile.Value = _profiles.Peek();
        }
        
        public override void Register(RatingButtonComponent component)
        {
            component.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("show next");
                RateAndShowNext(component.rating);
            });
        }

        public void RateAndShowNext(Rating rating)
        {
            ActiveProfile.Value.Rating = rating;
            _profiles.Enqueue(_profiles.Dequeue());
            ActiveProfile.Value = _profiles.Peek();
        }

        public Profile GenerateProfile()
        {
            var profile = ScriptableObject.CreateInstance<Profile>();
            profile.name = AmericanNameGenerator.GenerateName(AmericanNameGenerator.Gender.Neutral);
            profile.age = Random.Range(18, 99);
            profile.distance = Random.Range(0f, 1000f);

            var nameTrait = ScriptableObject.CreateInstance<PersonalityTrait>();
            nameTrait.category = Category.Name;
            nameTrait.text = profile.name;
            var allTraits = ScriptableObjectSearcher.GetAllPersonalityTraits()
                .Append(nameTrait).ToArray();
            var allTexts = ScriptableObjectSearcher.GetAllProfileTexts();

            var randomProfileTextTemplate = allTexts.RandomElement();
            var traits = randomProfileTextTemplate.Categories
                .Select(category => allTraits
                    .Where(t => t.category == category)
                    .ToArray()
                    .RandomElement());

            profile.text = randomProfileTextTemplate.CreateText(traits);

            return profile;
        }
    }
}