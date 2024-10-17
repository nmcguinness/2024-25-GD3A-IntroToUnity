using GD.Types;
using UnityEngine;

namespace GD
{
    // Interface to define the interaction method for interactable items.
    public interface IInteractable
    {
        public InteractableType Type { get; }
        public string Name { get; }
        public string Description { get; }
        public Transform Transform { get; }

        //Called when the player interacts with the object.
        public void Interact();
    }
}