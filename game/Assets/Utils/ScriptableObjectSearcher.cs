using System.Collections.Generic;
using UnityEngine;

namespace Assets.Utils
{
    public static class ScriptableObjectSearcher
    {
        public static IEnumerable<T> GetAllInstances<T>() where T : ScriptableObject
        {
            return Resources.LoadAll<T>("Profiles");
        }
    }
}
