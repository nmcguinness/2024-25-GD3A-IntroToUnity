using GD.Items;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// Store reference to entities/objects that the conditions need to check against.
    /// </summary>
    public class ConditionContext
    {
        // Used by the conditions to get the current state of the player
        private Player player;

        // Used by the conditions to get the current state of the inventory
        private InventoryCollection inventoryCollection;

        // Used by the conditions to get the current state of the game object
        private GameObject gameObject;

        public Player Player { get => player; set => player = value; }
        public InventoryCollection InventoryCollection { get => inventoryCollection; set => inventoryCollection = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        // Add other context dependencies here

        public ConditionContext(Player player, InventoryCollection inventoryCollection, GameObject gameObject)
        {
            Player = player;
            InventoryCollection = inventoryCollection;
            GameObject = gameObject;
        }

        public ConditionContext(Player player, InventoryCollection inventoryCollection)
            : this(player, inventoryCollection, null)
        {
        }

        public ConditionContext(Player player)
          : this(player, null, null)
        {
        }

        public ConditionContext(InventoryCollection inventoryCollection)
            : this(null, inventoryCollection, null)
        {
        }

        public ConditionContext(GameObject gameObject)
            : this(null, null, gameObject)
        {
        }

        public ConditionContext()
           : this(null, null, null)
        {
        }
    }
}