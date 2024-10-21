﻿using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "GD/Types/Variables/Vector3", order = 5)]
    public class Vector3Variable : ScriptableDataType<Vector3>
    {
        public void Add(Vector3 a)
        {
            Value += a;
        }

        public void Add(Vector3Variable a)
        {
            Add(a.Value);
        }
    }
}