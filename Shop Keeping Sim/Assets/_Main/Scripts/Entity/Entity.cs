using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The parent of all entities, has common variables and methods that they all use
/// </summary>
/// <typeparam name="T">The specific scriptable object the class uses</typeparam>
public class Entity<T> : MonoBehaviour
    where T : ScriptableObject
{
    [SerializeField] private StatsSO stats;

    /// <summary>
    /// Returns the scriptable object assigned as T
    /// </summary>
    /// <returns></returns>
    public virtual T GetData() => stats as T;
}
