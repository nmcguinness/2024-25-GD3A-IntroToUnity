using GD.Items;
using GD.State;
using GD.Types;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Inventory Equippable")]
public class InventoryEquippableCondition : ConditionBase
{
    [SerializeField]
    private ItemCategoryType itemCategoryType;

    [SerializeField]
    private ItemData itemData;

    [SerializeField]
    private int itemCount;

    protected override bool EvaluateCondition(ConditionContext conditionContext)
    {
        // Get the inventory for the item category for the stones
        var inventory = conditionContext.inventoryCollection.Get(itemCategoryType);

        // Check if the inventory contains the required number of stones
        return itemCount <= inventory.Count(itemData);
    }
}