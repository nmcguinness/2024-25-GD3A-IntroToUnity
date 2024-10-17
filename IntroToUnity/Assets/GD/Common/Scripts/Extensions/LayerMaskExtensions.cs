using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool OnLayer(this ref LayerMask target, GameObject gameObject) => ((1 << gameObject.layer) & target.value) != 0;
}