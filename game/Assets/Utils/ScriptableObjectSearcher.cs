using System.Collections.Generic;
using Systems.Profile.ScriptableObjects;
using UnityEngine;

namespace Assets.Utils
{
    public static class ScriptableObjectSearcher
    {
        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            return Resources.LoadAll<T>("");
        }

        public static PersonalityTrait[] GetAllPersonalityTraits()
        {
            return GetAllInstances<PersonalityTrait>();
        }

        public static ProfileText[] GetAllProfileTexts()
        {
            return GetAllInstances<ProfileText>();
        }
    }
}