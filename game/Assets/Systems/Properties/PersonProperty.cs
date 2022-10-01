using System;
using UnityEngine;

namespace Systems.Properties
{
    public enum PropertyLocation
    {
        Image,
        Text
    }
    
    [CreateAssetMenu]
    public class PersonProperty  : ScriptableObject
    {
        public Guid guid = new();
        public string name;
        public string text;
        public PropertyLocation propertyLocation;
    }
}