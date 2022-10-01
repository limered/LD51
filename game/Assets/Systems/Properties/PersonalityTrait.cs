using System;
using UnityEngine;

namespace Systems.Properties
{
    public enum PropertyLocation
    {
        Image,
        Text,
    }

    public enum Category
    {
        Name,
        FoodType,
        Pets,
        Sport,
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