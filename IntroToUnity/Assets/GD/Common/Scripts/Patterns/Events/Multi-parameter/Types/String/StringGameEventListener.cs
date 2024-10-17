using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEventListener that listens for StringGameEvent.
    // Listens for events that carry a string parameter and responds accordingly.
    [AddComponentMenu("GD/Events/String Event Listener")]
    public class StringGameEventListener
        : BaseGameEventListener<string>
    { }
}