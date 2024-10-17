using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEvent that carries a string parameter.
    // Used to create a string-based event that can be raised and responded to.
    [CreateAssetMenu(fileName = "StringGameEvent",
    menuName = "GD/SO/Events/String",
        order = 3)]
    public class StringGameEvent : BaseGameEvent<string>
    { }
}