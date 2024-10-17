using GD.Types;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "InteractableData", menuName = "GD/SO/Data/Interactable")]
    public class InteractableData : ScriptableObject, IInteractable
    {
        #region Fields

        [SerializeField]
        private InteractableType type = InteractableType.Resource;

        [SerializeField]
        private new string name;

        [SerializeField]
        private string description;

        [SerializeField]
        private Transform transform;

        #endregion Fields

        #region Properties

        public InteractableType Type { get => type; }
        public string Name { get => name; }
        public string Description { get => description; }
        public Transform Transform { get => transform; }

        #endregion Properties

        #region Methods

        public virtual void Interact()
        {
            //NOOP - see child classes for implementation
        }

        #endregion Methods
    }
}