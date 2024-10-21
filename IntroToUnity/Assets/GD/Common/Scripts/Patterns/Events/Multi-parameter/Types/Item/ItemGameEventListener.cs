using GD.Items;

namespace GD
{
    // Concrete implementation of BaseGameEventListener that listens for an integer-based event.
    // Used to create a listener that can listen for ItemGameEvent events and respond to them.
    public class InteractableEventListener : BaseGameEventListener<ItemData>
    { }
}