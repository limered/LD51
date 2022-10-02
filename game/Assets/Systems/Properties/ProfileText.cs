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
        /// "Hello, my name is {Name}. I love {Pets}. Searching for a partner with {Degree} {Personality}, who would take me to a trip to {TravelLocation} or {TravelLocation}."
        /// would have: Name, Pets, Degree, Personality, TravelLocation, TravelLocation
        /// </summary>
        public IEnumerable<Category> Categories
        {
            get
            {
                var names = typeof(Category).GetEnumNames();
                var values = typeof(Category).GetEnumValues();
                for (var i = 0; i < template.Length; i++)
                {
                    if (template[i] == '{')
                    {
                        for (var c = 0; c < names.Length; c++)
                        {
                            if (template.Substring(i).StartsWith($"{{{names[c]}}}"))
                            {
                                i += $"{{{names[c]}}}".Length - 1;
                                yield return (Category)values.GetValue(c);
                            }
                        }
                    }
                }
            }
        }

        public string CreateText(IEnumerable<PersonalityTrait> traits, string name)
        {
            var dict = new Dictionary<Category, List<string>>();
            foreach (var trait in traits)
            {
                if (dict.ContainsKey(trait.category))
                {
                    dict[trait.category].Add(trait.text);
                }
                else
                {
                    dict.Add(trait.category, new List<string> { trait.text });
                }
            }

            var text = "";
            for (var i = 0; i < template.Length; i++)
            {
                if (template[i] == '{')
                {
                    if (template.Substring(i).StartsWith("{Name}"))
                    {
                        i += "{Name}".Length - 1;
                        text += name;
                        continue;
                    }


                    foreach (var category in dict.Keys)
                    {
                        if (template.Substring(i).StartsWith($"{{{category}}}"))
                        {
                            i += $"{{{category}}}".Length - 1;
                            Debug.Assert(dict.ContainsKey(category), $"missing personality trait: {category}");
                            var what = dict[category].First();
                            text += what;
                            dict[category].RemoveAt(0);
                            dict[category].Add(what);
                            break;
                        }
                    }
                }
                else
                {
                    text += template[i];
                }
            }

            return text;
        }
    }
}