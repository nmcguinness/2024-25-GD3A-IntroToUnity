using UnityEngine;
using UnityEngine.UI;

public class ReticuleController : MonoBehaviour
{
    [SerializeField]
    private Image upper, lower, centre;

    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float fillAmountIncrement = 0.01f;

    [SerializeField]
    [Range(0.25f, 0.5f)]
    private float upperFillAmountThreshold = 0.5f;

    [SerializeField]
    [Range(0, 0.1f)]
    private float lowerFillAmountThreshold = 0.1f;

    /// <summary>
    /// Can call this from an IntGameEvent
    /// </summary>
    /// <param name="fillAmount"></param>
    public void SetFillAmount(int fillAmount)
    {
        if (fillAmount >= lowerFillAmountThreshold && fillAmount <= upperFillAmountThreshold)
        {
            upper.fillAmount = fillAmount;
            lower.fillAmount = fillAmount;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (upper.fillAmount + fillAmountIncrement <= upperFillAmountThreshold
            && lower.fillAmount + fillAmountIncrement <= upperFillAmountThreshold)
            {
                upper.fillAmount += fillAmountIncrement;
                lower.fillAmount += fillAmountIncrement;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (upper.fillAmount - fillAmountIncrement >= lowerFillAmountThreshold
                && lower.fillAmount - fillAmountIncrement >= lowerFillAmountThreshold)
            {
                upper.fillAmount -= fillAmountIncrement;
                lower.fillAmount -= fillAmountIncrement;
            }
        }
    }
}