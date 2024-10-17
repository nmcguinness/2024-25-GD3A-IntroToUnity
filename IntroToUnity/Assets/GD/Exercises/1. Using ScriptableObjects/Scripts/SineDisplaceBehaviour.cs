using UnityEngine;

public class SineDisplaceBehaviour : MonoBehaviour
{
    #region Fields

    [SerializeField]
    [Tooltip("Transform of the object to be displaced")]
    private Transform target;

    [SerializeField]
    [Range(0f, 5f)]
    private float amplitude = 1;

    [SerializeField]
    private Vector3 direction = Vector3.up;

    [SerializeField]
    [Range(0f, 25f)]
    private float frequencyScale = 1f;

    [SerializeField]
    [Range(-180, 180)]
    private float phaseAngleDegrees = 0f;

    private Vector3 originalPosition;
    private float elapsedTime;

    #endregion Fields

    private void Start()
    {
        direction = direction.normalized;
        originalPosition = target.transform.localPosition;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime; //16ms for 60HZ display
        var magnitude = amplitude * Mathf.Sin((elapsedTime * frequencyScale)
            + GD.GDMathf.ToRadians(phaseAngleDegrees));
        target.transform.localPosition = originalPosition + direction * magnitude;
    }
}