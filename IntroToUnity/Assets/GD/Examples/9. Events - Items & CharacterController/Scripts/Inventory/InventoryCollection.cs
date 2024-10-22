using GD.Items;
using GD.Types;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    //TODO - Fix Add on new ItemCategoryType

    [CreateAssetMenu(fileName = "InventoryCollection",
        menuName = "GD/Inventory/Collection")]
    public class InventoryCollection : SerializedScriptableObject
    {
        [SerializeField]
        private Dictionary<ItemCategoryType, Inventory> contents
            = new Dictionary<ItemCategoryType, Inventory>();

        //add a new inventory to the collection
        public void Add(ItemData itemData)
        {
            //if I never collected a Consumable
            if (!contents.ContainsKey(itemData.ItemCategory))
            {
                //make an inventory for consumables
                contents.Add(itemData.ItemCategory,
                    ScriptableObject.CreateInstance<Inventory>());
            }

            //add 1 specific consumable (e.g. ItemData = Apple) to the inventory
            contents[itemData.ItemCategory].Add(itemData, 1);
            //TODO - add more than 1?
        }
    }
}