using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Utils;
using SystemBase.Core;
using Systems.Properties;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Systems.Profile
{
    [GameSystem]
    public class ProfileSystem : GameSystem<ProfileComponent>
    {
        public override void Register(ProfileComponent displaySystem)
        {
            ProfileService.Init();
            ProfileService.ToNextProfile();
        }

        public Profile GenerateProfile()
        {
            var profile = ScriptableObject.CreateInstance<Profile>();
            profile.name = AmericanNameGenerator.GenerateName(AmericanNameGenerator.Gender.Neutral);
            profile.age = Random.Range(18, 99);
            profile.distance = Random.Range(0f, 2500f);

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