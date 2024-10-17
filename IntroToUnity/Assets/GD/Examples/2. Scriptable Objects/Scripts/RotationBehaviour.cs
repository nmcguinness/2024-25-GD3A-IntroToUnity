using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("D&D target for the rotation")]
    private Transform target;

    [SerializeField]
    private Vector3 axis = Vector3.up;

    [SerializeField]
    private FloatParameter angleInDegrees;

    private void Update()
    {
        //   Debug.Log($"Time between: {Time.deltaTime}");
        target.transform.Rotate(axis, angleInDegrees.value);
    }
}