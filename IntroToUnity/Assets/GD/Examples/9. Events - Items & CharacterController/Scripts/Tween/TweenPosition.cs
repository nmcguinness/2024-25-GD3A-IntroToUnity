using DG.Tweening;
using UnityEngine;

public class TweenPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The amount to move the object by")]
    private Vector3 moveDelta;

    [SerializeField]
    [Range(0.1f, 10f)]
    private float durationSecs = 0.1f;

    [SerializeField]
    private Ease easeFunction = Ease.Linear;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    // Start is called before the first frame update
    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;

        //transform.DOMove(originalPosition + moveDelta, durationSecs)
        //   .SetEase(easeFunction);

        transform.DOScale(originalScale * 1.5f, durationSecs)
           .SetEase(easeFunction)
           .SetLoops(3, LoopType.Yoyo)
           .OnComplete(() => Debug.Log("Tween Complete"));
    }
}