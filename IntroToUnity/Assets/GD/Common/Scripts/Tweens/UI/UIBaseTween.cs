using DG.Tweening;
using GD.Types;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.StateUpdaters;
using UnityEngine;
using UnityEngine.Events;

namespace GD.Tweens
{
    /// <summary>
    /// Base class for UI panel tweens that can fade, slide, etc.
    /// </summary>
    public abstract class UIBaseTween : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("Specify the KeyCode to toggle the panel's visibility")]
        protected KeyCode keyCode = KeyCode.M;

        [SerializeField]
        [Tooltip("Common settings for the tween")]
        protected TweenSettings tweenSettings;

        [SerializeField, Tooltip("Event to call when the tween has completed")]
        [PropertyOrder(20)]
        protected UnityEvent onComplete;

        [SerializeField, ReadOnly]
        [PropertyOrder(30)]
        protected VisibilityState visibilityState = VisibilityState.Hidden;

        #endregion Fields

        #region Properties

        protected float DurationSecs => tweenSettings.DurationSecs;
        protected float DelaySecs => tweenSettings.DelaySecs;
        protected Ease ShowEase => tweenSettings.ShowEase;
        protected Ease HideEase => tweenSettings.HideEase;

        #endregion Properties

        #region Methods

        protected virtual void Start()
        {
            InitializePanel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
                TogglePanel();
        }

        public void TogglePanel()
        {
            if (visibilityState == VisibilityState.Visible)
                Hide();
            else if (visibilityState == VisibilityState.Hidden)
                Show();
        }

        protected virtual void InitializePanel()
        {
            visibilityState = VisibilityState.Hidden;
        }

        protected virtual void Show()
        {
            visibilityState = VisibilityState.Showing;
        }

        protected virtual void Hide()
        {
            visibilityState = VisibilityState.Hiding;
        }

        protected virtual void TweenComplete()
        {
            if (visibilityState == VisibilityState.Showing)
                visibilityState = VisibilityState.Visible;
            else if (visibilityState == VisibilityState.Hiding)
                visibilityState = VisibilityState.Hidden;

            onComplete?.Invoke();
        }

        #endregion Methods
    }
}