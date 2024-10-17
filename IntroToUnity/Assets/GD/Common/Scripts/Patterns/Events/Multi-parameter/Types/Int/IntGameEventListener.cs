using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEventListener that listens for IntGameEvent.
    // Listens for events that carry an int parameter and responds accordingly.
    [AddComponentMenu("GD/Events/Int Event Listener")]
    public class IntGameEventListener : BaseGameEventListener<int>
    { }
}