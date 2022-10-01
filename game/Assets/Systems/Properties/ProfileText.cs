using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Systems.Properties
{
    [CreateAssetMenu]
    public class ProfileText : ScriptableObject
    {
        public Guid guid = new();
        public string template;

        /// <summary>
        /// Get all categories of template text:
        /// "Hello, my name is {Name}. I love {Pets}. Searching for a partner with {Degree} {Personality}, who would take me to a trip to {TravelLocation}."
        /// would have: Name, Pets, Degree, Personality, TravelLocation
        /// </summary>
        public IEnumerable<Category> Categories
        {
            get
            {
                var names = typeof(Category).GetEnumNames();
                var values = typeof(Category).GetEnumValues();
                for (var i = 0; i < values.Length; i++)
                {
                    if (template.Contains($"{{{names[i]}}}"))
                    {
                        yield return (Category)values.GetValue(i);
                    }
                }
            }
        }

        public string Create(IEnumerable<PersonalityTrait> traits)
        {
            return null;
        }
    }
}