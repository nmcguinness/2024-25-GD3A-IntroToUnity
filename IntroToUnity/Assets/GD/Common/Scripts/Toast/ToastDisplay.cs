using UnityEngine;
using UnityEngine.UI;

namespace GD.Toast
{
    /// <summary>
    /// Handles the display and animation of a single toast message.
    /// </summary>
    public class ToastDisplay : MonoBehaviour
    {
        [ReadOnly, SerializeField]
        private Text toastText;

        [ReadOnly, SerializeField]
        private Animator animator;

        private void Awake()
        {
            toastText = GetComponentInChildren<Text>();
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Initializes the toast message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void Initialize(string message)
        {
            if (toastText != null)
            {
                toastText.text = message;
            }
        }

        /// <summary>
        /// Triggers the show animation.
        /// </summary>
        public void Show()
        {
            if (animator != null)
            {
                animator.SetTrigger("Show");
            }
        }

        /// <summary>
        /// Triggers the hide animation.
        /// </summary>
        public void Hide()
        {
            if (animator != null)
            {
                animator.SetTrigger("Hide");
            }
        }
    }
}