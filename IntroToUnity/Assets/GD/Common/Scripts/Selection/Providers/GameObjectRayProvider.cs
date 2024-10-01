using UnityEngine;

namespace GD.Selection
{
    public class GameObjectRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        private GameObject targetObject;

        [ReadOnly]
        private Ray ray;

        public Ray CreateRay()
        {
            ray = new Ray(targetObject.transform.position, targetObject.transform.forward);
            return ray;
        }
    }
}