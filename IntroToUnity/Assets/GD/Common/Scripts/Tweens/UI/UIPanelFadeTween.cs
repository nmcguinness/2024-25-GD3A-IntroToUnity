using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace GD.UI
{
    /// <summary>
    /// Adds a fade-in and fade-out tween to a UI panel using DOTween.
    /// </summary>
    public class UIPanelFadeTween : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Specify the KeyCode to toggle the panel's visibility")]
        private KeyCode keyCode = KeyCode.M;

        [SerializeField]
        [Tooltip("Specify the CanvasGroup component of the UI panel for fading")]
        private CanvasGroup panelCanvasGroup; // CanvasGroup is required to adjust opacity

        [FoldoutGroup("Tween Settings", expanded: true)]
        [SerializeField]
        [Tooltip("Specify the duration of the fade animation in seconds")]
        private float fadeDuration = 0.5f; // Duration of the fade animation

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        [Tooltip("Ease type for the fade-in animation")]
        private Ease fadeInEase = Ease.OutQuad;

        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        [Tooltip("Ease type for the fade-out animation")]
        private Ease fadeOutEase = Ease.InQuad;

        [TabGroup("Events")]
        [SerializeField]
        [Tooltip("Event to call when the tween has completed")]
        private UnityEvent onComplete;

        // Boolean to keep track of the panel's current visibility state
        private bool isVisible = false;

        private void Start()
        {
            // Initialize the panel's alpha to 0 so it's hidden at start
            panelCanvasGroup.alpha = 0;
        }

        private void Update()
        {
            // Check if the "M" key is pressed to toggle the panel's visibility
            if (Input.GetKeyDown(keyCode))
                TogglePanel();
        }

        // Toggles the panel's visibility by fading it in or out
        [Button("Toggle Panel")]
        private void TogglePanel()
        {
            if (isVisible)
                FadeOut();
            else
                FadeIn();

            isVisible = !isVisible; // Toggle the isVisible boolean to track the current state
        }

        // Fades the panel in by adjusting the alpha to 1

        private void FadeIn()
        {
            panelCanvasGroup.DOFade(1, fadeDuration)
                .SetEase(fadeInEase)
                     .OnComplete(TweenComplete);
            //TODO: ALL - Add onComplete, SetDelay, etc. to the tween
        }

        // Fades the panel out by adjusting the alpha to 0

        private void FadeOut()
        {
            panelCanvasGroup.DOFade(0, fadeDuration)
                .SetEase(fadeOutEase)
                         .OnComplete(TweenComplete);

            //TODO: ALL - Add onComplete, SetDelay, etc. to the tween
        }

        private void TweenComplete()
        {
            onComplete?.Invoke();
        }
    }
}