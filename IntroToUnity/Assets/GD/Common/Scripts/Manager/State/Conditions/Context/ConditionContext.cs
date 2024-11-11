using GD.Items;

namespace GD.State
{
    /// <summary>
    /// Store reference to entities/objects that the conditions need to check against.
    /// </summary>
    public class ConditionContext
    {
        //Used by the conditions to get the current state of the player
        public Player player;

        //Used by the conditions to get the current state of the inventory
        public InventoryCollection inventoryCollection;

        //Add other context dependencies here

        public ConditionContext(Player player, InventoryCollection inventoryCollection)
        {
            this.player = player;
            this.inventoryCollection = inventoryCollection;
        }
    }
}