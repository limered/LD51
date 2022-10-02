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
        Food = 0,
        Pets = 1,
        Sport = 2,
        Hobby = 3,
        TravelLocation = 4,
        Shape = 5,
        Relation = 6,
        Religion = 7,
        Personality = 8,
        Music = 9,
        Movies = 10,
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