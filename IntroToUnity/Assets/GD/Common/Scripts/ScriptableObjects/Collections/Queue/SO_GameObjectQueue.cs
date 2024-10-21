﻿using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_GameObjectQueue", menuName = "GD/Types/Collections/Queue/Game Object", order = 7)]
    public class SO_GameObjectQueue : SO_Queue<GameObject>
    {
    }
}