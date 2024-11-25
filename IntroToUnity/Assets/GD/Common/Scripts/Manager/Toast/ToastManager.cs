using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// Manages the display of toast messages in a queue.
    /// </summary>
    public class ToastManager : Singleton<ToastManager>
    {
        [ReadOnly, SerializeField]
        private bool isProcessing = false;

        private Queue<Toast> toastQueue = new Queue<Toast>();
        private IToastFactory toastFactory;

        /// <summary>
        /// Sets the factory used to create toast objects.
        /// </summary>
        public void SetToastFactory(IToastFactory factory)
        {
            toastFactory = factory;
        }

        /// <summary>
        /// Adds a new toast to the queue.
        /// </summary>
        public void AddToast(string message, float duration, float delay)
        {
            AddToast(new Toast(message, duration, delay));
        }

        /// <summary>
        /// Adds a new toast to the queue.
        /// </summary>
        public void AddToast(Toast toast)
        {
            toastQueue.Enqueue(toast);

            if (!isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            isProcessing = true;

            while (toastQueue.Count > 0)
            {
                Toast toast = toastQueue.Dequeue();

                // Delay before showing
                yield return new WaitForSeconds(toast.Delay);

                // Create and show toast
                GameObject toastObject = toastFactory.GetToast(toast.Message);
                ToastDisplay display = toastObject.GetComponent<ToastDisplay>();
                display.Show();

                // Wait for the duration
                yield return new WaitForSeconds(toast.Duration);

                // Hide and destroy the toast
                display.Hide();
                yield return new WaitForSeconds(1.0f); // Assume 1 second for hide animation

                Destroy(toastObject);
            }

            isProcessing = false;
        }
    }
}