using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ScriptableObjectsFinder : MonoBehaviour
{
#if UNITY_EDITOR
    public static List<T> GetAllInstancesInPath<T>(string path) where T : ScriptableObject
    {
        return AssetDatabase.FindAssets($"t: {typeof(T).Name}", new[] { path }).ToList()
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Select(AssetDatabase.LoadAssetAtPath<T>)
                    .ToList();
    }
#endif
}
