using GD;
using GD.Types;
using UnityEngine;

/// <summary>
/// Demo of sharing a FloatReference (SO) between entities that use this script
/// </summary>
public class SharedSineDisplaceBehaviour : MonoBehaviour
{
    #region Fields

    [SerializeField]
    [Tooltip("Transform of the object to be displaced")]
    private Transform target;

    [SerializeField]
    private FloatVariable amplitude;

    //[Range(0f, 5f)]
    //private float amplitude = 1;

    [SerializeField]
    private Vector3Reference direction;

    //private Vector3 direction = Vector3.up;

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
        originalPosition = target.transform.localPosition;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime; //16ms for 60HZ display
        var magnitude = amplitude.Value * Mathf.Sin((elapsedTime * frequencyScale)
            + GD.GDMathf.ToRadians(phaseAngleDegrees));
        target.transform.localPosition = originalPosition
            + direction.Value * magnitude;
    }
}