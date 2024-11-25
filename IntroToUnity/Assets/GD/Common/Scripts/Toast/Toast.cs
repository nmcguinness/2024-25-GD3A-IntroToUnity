using GD.Types;
using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// ScriptableObject representing a toast message.
    /// </summary>
    [CreateAssetMenu(fileName = "NewToast", menuName = "GD/Toasts/Standard", order = 1)]
    public class Toast : ScriptableGameObject
    {
        [TextArea]
        [Tooltip("The message to display in the toast.")]
        private string message;

        [Tooltip("Duration for which the toast is displayed (in seconds).")]
        private float duration = 2.0f;

        [Tooltip("Delay before showing the toast (in seconds).")]
        private float delay = 0.0f;

        public string Message { get => message; set => message = value; }
        public float Duration { get => duration; set => duration = value; }
        public float Delay { get => delay; set => delay = value; }
    }
}