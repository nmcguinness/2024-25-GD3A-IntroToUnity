using DG.Tweening;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace GD.Tweens
{
    /// <summary>
    /// Scales a UI panel on the screen
    /// </summary>
    public class ScaleTween : UIBaseTween
    {
        [SerializeField, Tooltip("Specify the RectTransform of the UI panel that will slide in/out")]
        private RectTransform panel;

        [SerializeField, Tooltip("Target scale when the panel is visible")]
        private Vector3 targetScale = Vector3.one;

        [SerializeField, Tooltip("Initial scale when the panel is hidden")]
        private Vector3 hiddenScale = Vector3.zero;

        protected override void InitializePanel()
        {
            base.InitializePanel();

            panel.localScale = hiddenScale;
        }

        protected override void Show()
        {
            base.Show();

            panel.DOScale(targetScale, DurationSecs)
                .SetEase(ShowEase)
                .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }

        protected override void Hide()
        {
            base.Hide();

            panel.DOScale(hiddenScale, DurationSecs)
                .SetEase(HideEase)
                .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }
    }
}