using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Utils
{
    public static class ScriptableObjectSearcher
    {
        public static IEnumerable<T> GetAllInstances<T>() where T : ScriptableObject
        {
            foreach (var asset in AssetDatabase.FindAssets("t:" + typeof(T).Name))
            {
                var path = AssetDatabase.GUIDToAssetPath(asset);
                yield return AssetDatabase.LoadAssetAtPath<T>(path);
            }
        }
    }
}
