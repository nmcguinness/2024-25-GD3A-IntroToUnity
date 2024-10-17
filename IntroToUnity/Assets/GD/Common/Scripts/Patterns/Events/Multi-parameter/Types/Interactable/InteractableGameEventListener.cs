using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEventListener that listens for an InteractableData event.
    // Used to create an InteractableData-based listener that can be used to respond to an event.
    [AddComponentMenu("GD/Events/Interactable Event Listener")]
    public class InteractableEventListener : BaseGameEventListener<InteractableData>
    { }
}