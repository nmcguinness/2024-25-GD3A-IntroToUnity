using GD.Items;

#region GD.Tasks

/// <summary>
/// TaskContext acts as a container for dependencies that tasks may require.
/// It is instantiated by the TaskManager and passed to tasks upon execution.
/// </summary>
public class TaskContext
{
    //Used by the conditions to get the current state of the player
    public Player player;

    //Used by the conditions to get the current state of the inventory
    public InventoryCollection inventoryCollection;

    //Add other context dependencies here

    public TaskContext(Player player, InventoryCollection inventoryCollection)
    {
        this.player = player;
        this.inventoryCollection = inventoryCollection;
    }
}

#endregion GD.Tasks