using UnityEngine;

namespace GD
{
    public class MaterialChangeBehaviour : MonoBehaviour
    {
        [SerializeField]
        [ColorUsage(true, true)]
        private Color newColor;

        private Material currentMaterial;

        // Start is called before the first frame update
        private void Start()
        {
            currentMaterial = GetComponent<MeshRenderer>().material;
        }

        /// <summary>
        /// Called by the EventManagers when the event is raised
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="target"></param>
        public void SetSomethingElse(string name, int value, bool target)
        {
            Debug.Log($"{name},{value},{target}");
        }

        /// <summary>
        /// Called by the EventManagers when the event is raised
        /// </summary>
        public void SetColor()
        {
            currentMaterial.color = newColor;
        }
    }
}