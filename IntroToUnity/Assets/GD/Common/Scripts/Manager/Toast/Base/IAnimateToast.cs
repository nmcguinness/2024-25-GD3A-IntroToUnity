using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// Base interface for animating toasts
    /// </summary>
    public interface IAnimateToast
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="toastUI"></param>
        /// <param name="duration"></param>
        /// <param name="onComplete">Reference to a function (return type void) to call when I'm finished</param>
        void AnimateToast(GameObject toastUI, float duration, System.Action onComplete);
    }
}