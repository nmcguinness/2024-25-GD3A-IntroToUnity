using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Plays a user-defined audioclip once on new selection from position of selected object
    /// </summary>
    /// <see cref="AdvancedSelectionManager"/>
    public class AudioSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField]
        private AudioClip clip;

        //reference to the last object selected in OnSelect
        private Transform oldTransform;

        public void OnSelect(Transform transform)
        {
            if (oldTransform != null && transform != oldTransform)
                AudioSource.PlayClipAtPoint(clip, transform.position);

            oldTransform = transform;
        }

        public void OnDeselect(Transform transform)
        {
        }
    }
}