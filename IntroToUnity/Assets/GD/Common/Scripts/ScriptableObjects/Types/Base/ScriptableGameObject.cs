using UnityEngine;

namespace GD
{
    public class ScriptableGameObject : ScriptableObject
    {
        #region Fields

        [Header("General Info")]
        [ContextMenuItem("Reset Name", "ResetName")]
        [SerializeField]
        private new string name = string.Empty;

        [ContextMenuItem("Reset Description", "ResetDescription")]
        [TextArea(2, 4)]
        private string description = string.Empty;

        #endregion Fields

        #region Properties

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }

        #endregion Properties

        #region Core Methods

        /// <summary>
        /// Resets the name to an empty string
        /// </summary>
        public void ResetName()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Resets the description to an empty string
        /// </summary>
        public void ResetDescription()
        {
            Description = string.Empty;
        }

        /// <summary>
        /// Overridden in child classes to specify what a reset means (e.g. clear the list, reset the int, empty the string
        /// </summary>
        public virtual void Reset()
        {
            //noop - (no operation - not called)
        }

        #endregion Core Methods
    }
}