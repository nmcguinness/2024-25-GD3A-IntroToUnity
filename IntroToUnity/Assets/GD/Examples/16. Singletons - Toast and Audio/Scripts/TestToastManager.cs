using GD.Toast;
using UnityEngine;

public class TestToastManager : MonoBehaviour
{
    private void Start()
    {
        // Test case: Display a single toast
        ToastManager.Instance.AddToast("Ready!!!", 3, 0);

        // Test case: Display multiple toasts in a queue
        ToastManager.Instance.AddToast("3...", 0.5f, 0);
        ToastManager.Instance.AddToast("2...", 0.5f, 0);
        ToastManager.Instance.AddToast("1...", 0.5f, 0);

        // Test case: Adding a toast with a delay before showing
        ToastManager.Instance.AddToast("Go!!!", 1, 0);
    }

    private void Update()
    {
        // Optional: Add input-driven tests
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToastManager.Instance.AddToast("Toast triggered by T key!", 2f, 0f);
        }
    }
}