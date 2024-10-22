using GD;
using GD.Items;
using Unity.VisualScripting;
using UnityEngine;

namespace GD
{
    public class InventoryManager : MonoBehaviour
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
}