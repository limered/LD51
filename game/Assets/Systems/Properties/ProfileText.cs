using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Properties
{   
    /// <summary>
    /// template text contains placeholder in form {??}
    /// {name}: Anna Bell, Irvin Irwich, ...
    /// {food_type}: vegetarian, carnivore, vegan, paleo 
    /// {hobby}: tennis, football, cooking, tattoos, netflix, swimming
    /// {travel_location}: paris, north pole, hell, disneyland, ...
    /// {random}: vegetarian, carnivore, vegan, paleo, ...
    /// {religion}: dooms day cult, happy tree friends, atheism, ...
    /// {degree}: hard, soft, long, cool, hot, dark, bright,...
    /// {relationship}: friends, homies, bros, family, sisters, coworkers, ... 
    /// </summary>
    [CreateAssetMenu]
    public class ProfileText : ScriptableObject
    {
        public Guid guid = new();
        public string template;

        public IEnumerable<PersonalityTrait> Traits
        {
            get
            {
                return null;
            }
        }
        
        public string Create(IEnumerable<PersonalityTrait> traits)
        {
            return null;
        }
    }
}