using System;
using UnityEngine;

namespace Systems.Profile.ScriptableObjects
{
    public enum PropertyLocation
    {
        Text,
        Image,
    }

    public enum Category
    {
        Food,
        Pets,
        Sport,
        Hobby,
        TravelLocation,
        Degree,
        Relation,
        Religion,
        Personality,
        Music,
    }
    
    [CreateAssetMenu(menuName = "LD51/Trait", fileName = "PersonalityTrait")]
    public class PersonalityTrait  : ScriptableObject
    {
        public Guid guid = new();
        public Category category;
        public string text;
        public PropertyLocation propertyLocation;
    }
}