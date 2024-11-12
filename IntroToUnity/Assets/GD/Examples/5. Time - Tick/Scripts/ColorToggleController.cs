using GD.Tick;
using UnityEngine;
using UnityEngine.Events;

namespace GD.Examples
{
    public class ColorToggleController : MonoBehaviour, IHandleTicks
    {
        [SerializeField]
        private TimeTickSystem.TickRateMultiplierType tickRateMultiplierType = TimeTickSystem.TickRateMultiplierType.BaseInterval;

        [SerializeField]
        [ColorUsage(false)]
        private Color alternateColor = Color.white;

        //some variables to actually do something in the demo
        private Material material;

        private Color originalColor;
        private bool toggleColor;

        private void Awake()
        {
            //notice that we have to cast using "as" otherwise it will just be a reference to a Singleton<MonoBehaviour>
            TimeTickSystem.Instance.RegisterListener(tickRateMultiplierType,
                HandleTick);

            //store material and original color
            material = GetComponent<MeshRenderer>().material;
            originalColor = material.color;
        }

        private void OnDestroy()
        {
            //don't forget to un-register!
            TimeTickSystem.Instance.UnregisterListener(tickRateMultiplierType,
                HandleTick);
        }

        public void HandleTick()
        {
            //call the code that we want to execute on each Tick event...

            //swap color on each tick
            if (toggleColor)
                material.color = originalColor;
            else
                material.color = alternateColor;

            toggleColor = !toggleColor;
        }
    }
}