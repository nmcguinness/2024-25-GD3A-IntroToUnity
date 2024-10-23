using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Uses DoTween to tween the position of the object.
/// </summary>
public class TweenPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The amount to move the object by")]
    private Vector3 positionDelta = Vector3.up;

    [SerializeField]
    [Range(0.1f, 10f)]
    [Tooltip("The duration of the tween in seconds")]
    private float durationSecs = 0.1f;

    [SerializeField]
    [Tooltip("The ease function to use for the tween")]
    private Ease easeFunction = Ease.Linear;

    [SerializeField]
    [Range(-1, 100)]
    private int loopCount = 1;

    [SerializeField]
    [Tooltip("The type of loop to use for the tween")]
    private LoopType loopType = LoopType.Restart;

    [SerializeField]
    [Tooltip("Event to call when the tween has completed")]
    private UnityEvent onComplete;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    private void Start()
    {
        //Save the original position of the object
        originalPosition = transform.position;

        //Start the tween
        StartTween();
    }

    /// <summary>
    /// Called to start the tween.
    /// </summary>
    public void StartTween()
    {
        //Move the object by the positionDelta over the durationSecs using the easeFunction and the loopCount and loopType
        transform.DOMove(originalPosition + positionDelta, durationSecs)
           .SetEase(easeFunction)
           .SetLoops(loopCount, loopType)
           .OnComplete(OnComplete);
    }

    /// <summary>
    /// Called when the tween has completed.
    /// </summary>
    protected void OnComplete()
    {
        //Notify listeners that the tween has completed
        onComplete?.Invoke();
    }
}