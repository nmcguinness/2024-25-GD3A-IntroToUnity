using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// Factory for creating toast objects.
    /// </summary>
    public class ToastFactory : IToastFactory
    {
        private GameObject toastPrefab;
        private Transform parentTransform;

        public ToastFactory(GameObject prefab, Transform parent)
        {
            toastPrefab = prefab;
            parentTransform = parent;
        }

        /// <summary>
        /// Creates a toast object.
        /// </summary>
        public GameObject GetToast(string message)
        {
            GameObject toastObject = Object.Instantiate(toastPrefab, parentTransform);
            ToastDisplay display = toastObject.GetComponent<ToastDisplay>();
            display.Initialize(message);
            return toastObject;
        }
    }
}