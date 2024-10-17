using UnityEngine;

namespace GD
{
    // Base class representing a common interactable object in the game.
    // This class serves as the base for all interactable/collectible items.
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Data for the interactable item.")]
        [RequireInterface(typeof(IInteractable))]
        protected InteractableData interactableData;
    }
}