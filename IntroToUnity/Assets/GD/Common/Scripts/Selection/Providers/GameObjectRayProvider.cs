using Unity.Android.Types;
using UnityEngine;

namespace GD.Selection
{
    public class GameObjectRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        private GameObject targetObject;

        [Header("Debug Gizmo Properties")]
        [SerializeField]
        private Color rayColor = Color.yellow;

        [SerializeField]
        [Range(0.1f, 100)]
        private float rayLength = 10;

        [ReadOnly] private Ray ray;

        public Ray CreateRay()
        {
            ray = new Ray(targetObject.transform.position, targetObject.transform.forward);
            return ray;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = rayColor;
            Gizmos.DrawLine(targetObject.transform.position,
                targetObject.transform.position + targetObject.transform.forward * rayLength);

            // Gizmos.DrawWireSphere(targetObject.transform.position, 2);
        }
    }
}