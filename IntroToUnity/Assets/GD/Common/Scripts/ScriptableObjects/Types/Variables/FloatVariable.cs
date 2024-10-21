using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "FloatVariable",
        menuName = "GD/Types/Variables/Float", order = 3)]
    public class FloatVariable : ScriptableDataType<float>
    {
        public void Add(float a)
        {
            Value += a;
        }

        public void Add(FloatVariable a)
        {
            Add(a.Value);
        }
    }
}