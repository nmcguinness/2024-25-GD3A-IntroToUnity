using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace GD.UI
{
    /// <summary>
    /// Adds a slide-in and slide-out tween to a UI panel using DOTween.
    /// </summary>
    public class UIPanelSlideTween : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Specify the KeyCode to toggle the panel's visibility")]
        private KeyCode keyCode = KeyCode.M;

        // Reference to the RectTransform of the UI panel that will slide in/out
        [SerializeField]
        [Tooltip("Specify the RectTransform of the UI panel that will slide in/out")]
        private RectTransform panel;

        // Position off-screen in the top-left corner, where the panel starts and hides
        [SerializeField]
        [Tooltip("Specify the off-screen position of the panel")]
        private Vector2 offScreenPosition = new Vector2(-500, 500);

        // Target position on the screen where the panel should slide to when visible
        [SerializeField]
        [Tooltip("Specify the on-screen position of the panel")]
        private Vector2 onScreenPosition = Vector2.zero;

        // Duration of the slide animation in seconds
        [FoldoutGroup("Tween Settings", expanded: true)]
        [SerializeField]
        [Tooltip("Specify the duration of the slide animation in seconds")]
        private float slideDuration = 0.5f;

        // Ease type for the slide-in animation, selectable from the Inspector
        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        [Tooltip("Ease type for the slide-in animation, selectable from the Inspector")]
        private Ease slideInEase = Ease.OutBack;

        // Ease type for the slide-out animation, selectable from the Inspector
        [FoldoutGroup("Tween Settings")]
        [SerializeField]
        [Tooltip("Ease type for the slide-out animation, selectable from the Inspector")]
        private Ease slideOutEase = Ease.InBack;

        // Boolean to keep track of the panel's current visibility state
        private bool isVisible = false;

        // Start is called before the first frame update
        private void Start()
        {
            // Initialize the panel's position to the off-screen position so it's hidden at start
            panel.anchoredPosition = offScreenPosition;
        }

        // Update is called once per frame
        private void Update()
        {
            // Check if the "M" key is pressed to toggle the panel's visibility
            if (Input.GetKeyDown(keyCode))
                TogglePanel();
        }

        // Toggles the panel's visibility by sliding it in or out
        [Button("Toggle Panel")]
        private void TogglePanel()
        {
            // If the panel is currently visible, slide it out
            if (isVisible)
                SlideOut();
            else // If the panel is hidden, slide it in
                SlideIn();

            // Toggle the isVisible boolean to keep track of the current state
            isVisible = !isVisible;
        }

        // Slides the panel in from the off-screen position to the on-screen position
        private void SlideIn()
        {
            // Animate the panel's anchored position to the on-screen position with specified easing
            panel.DOAnchorPos(onScreenPosition, slideDuration)
                .SetEase(slideInEase);

            //TODO: ALL - Add onComplete, SetDelay, etc. to the tween
        }

        // Slides the panel out from the on-screen position to the off-screen position
        private void SlideOut()
        {
            // Animate the panel's anchored position to the off-screen position with specified easing
            panel.DOAnchorPos(offScreenPosition, slideDuration)
                .SetEase(slideOutEase);

            //TODO: ALL - Add onComplete, SetDelay, etc. to the tween
        }
    }
}