﻿using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_FloatQueue", menuName = "GD/SO/Types/Collections/Queue/Float", order = 3)]
    public class SO_FloatQueue : SO_Queue<float>
    {
    }
}