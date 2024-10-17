using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEvent that carries an int parameter.
    // Used to create an integer-based event that can be raised and responded to.
    [CreateAssetMenu(fileName = "IntGameEvent",
        menuName = "GD/SO/Events/Int",
        order = 2)]
    public class IntGameEvent : BaseGameEvent<int>
    { }
}