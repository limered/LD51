using System;
using UnityEngine;

namespace Systems.Properties
{
    public enum PropertyLocation
    {
        Text,
        Image,
    }

    public enum Category
    {
        Name,
        FoodType,
        Pets,
        Sport,
        Hobby,
        TravelLocation,
        Degree,
        Relation,
        Religion,
    }
    
    [CreateAssetMenu]
    public class PersonalityTrait  : ScriptableObject
    {
        public Guid guid = new();
        public Category category;
        public string text;
        public PropertyLocation propertyLocation;
    }
}