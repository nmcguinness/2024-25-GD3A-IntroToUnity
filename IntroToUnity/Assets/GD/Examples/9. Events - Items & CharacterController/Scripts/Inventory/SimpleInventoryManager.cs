using GD;
using GD.Items;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleInventoryManager : MonoBehaviour
{
    [SerializeField]
    private InventoryCollection inventoryCollection;

    /// <summary>
    /// Adds the item to the inventory.
    /// </summary>
    /// <param name="data"></param>
    public void OnInteractablePickup(ItemData data)
    {
        inventoryCollection.Add(data);
    }
}