using System.Collections;
using TMPro;
using UnityEngine;
using GD.Events;

namespace GD.UI
{
    public class CountdownToastBehaviour : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Canvas object used to display the countdown")]
        private Canvas toastCanvas;

        [SerializeField]
        [Tooltip("TextMeshPro object used to display the countdown")]
        private TextMeshProUGUI countdownText;

        [SerializeField]
        [Tooltip("Starting value for the countdown")]
        private int startValue;

        [SerializeField]
        [Tooltip("Delay between each countdown value in seconds")]
        private float delayBetweenSecs;

        [SerializeField]
        [Tooltip("Event to raise when the countdown is completed")]
        private GameEvent onCompleted;

        public void StartCountdown()
        {
            toastCanvas.gameObject.SetActive(true);
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            int currentValue = startValue;

            while (currentValue > 0)
            {
                countdownText.text = currentValue.ToString();
                yield return new WaitForSeconds(delayBetweenSecs);
                currentValue--;
            }

            countdownText.text = "Go!";
            yield return new WaitForSeconds(delayBetweenSecs);

            toastCanvas.gameObject.SetActive(false);

            // Raise the event to signal countdown completion
            onCompleted?.Raise();
        }
    }
}