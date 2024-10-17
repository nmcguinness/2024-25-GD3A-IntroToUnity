using UnityEngine;

/// <summary>
/// Implemented by ScriptableObjects that can generate a prefab
/// </summary>
/// <see cref="InstantiatePrefab"/>
public interface IInstantiatePrefab
{
    /// <summary>
    /// Generate a prefab at the specified transform
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    GameObject Instantiate(Transform transform);
}