using GD.Items;
using UnityEngine;

/// <summary>
/// Set player move/attack/recover rates based on inventory contents.
/// </summary>
public class SimplePlayerPerformanceManager : MonoBehaviour
{
    [SerializeField]
    private InventoryCollection inventoryCollection;

    // [SerializeField]
    // private Player player;

    public void OnInventoryChange()
    {
        //TODO - recalculate player performance based on inventory contents

        //   var weight = inventoryCollection.GetTotalWeight();
        //   player.SetPerformance(weight);

        Debug.Log("Inventory changed!");
    }
}