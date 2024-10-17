using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "GD/SO/Types/Variables/String", order = 4)]
    public class StringVariable : ScriptableDataType<string>
    {
        public void Add(string a)
        {
            Value += a;
        }

        public void Add(StringVariable a)
        {
            Add(a.Value);
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Value);
        }
    }
}