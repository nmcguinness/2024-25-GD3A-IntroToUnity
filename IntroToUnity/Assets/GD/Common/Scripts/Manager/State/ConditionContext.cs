using GD.Items;

namespace GD.State
{
    /// <summary>
    /// Simply an envelope to pass through the state system to interested conditions
    /// </summary>
    public class ConditionContext
    {
        public Player player;
        public InventoryCollection inventoryCollection;

        //Add/remove context items/references based on the needs of the conditions

        public ConditionContext(Player player,
            InventoryCollection inventoryCollection)
        {
            this.player = player;
            this.inventoryCollection = inventoryCollection;
        }
    }
}