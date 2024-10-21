using GD.Items;
using UnityEngine;

public class SimpleInventoryManager : MonoBehaviour
{
    [SerializeField]
    private SimpleInventory inventory;

    /// <summary>
    /// Adds the item to the inventory.
    /// </summary>
    /// <param name="data"></param>
    public void OnInteractablePickup(ItemData data)
    {
        inventory.Add(data, 1);
    }
}