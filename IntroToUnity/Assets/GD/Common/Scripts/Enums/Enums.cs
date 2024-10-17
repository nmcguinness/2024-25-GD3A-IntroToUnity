namespace GD.Types
{
    /// <summary>
    /// A five-level priority system used to determine the importance of a task, event, or object.
    /// </summary>
    public enum PriorityLevel : sbyte
    {
        [Description("This is the lowest priority.")]
        Lowest = 1,

        [Description("This is a low priority.")]
        Low = 2,

        [Description("This is a medium priority.")]
        Medium = 3,

        [Description("This is a high priority.")]
        High = 4,

        [Description("This is the highest priority.")]
        Highest = 5
    }

    /// <summary>
    /// The type of interactable object.
    /// </summary>
    /// <see cref="InteractableData"/>
    public enum InteractableType
    {
        [Description("Non-playable character")]
        NPC,

        [Description("A door that can be opened or closed")]
        Door,

        [Description("A container such as a chest or bag")]
        Container,

        [Description("An object that triggers or advances a quest")]
        Quest,

        [Description("A sign that displays information")]
        Sign,

        [Description("Furniture item like a chair or table")]
        Furniture,

        [Description("A weapon that can be equipped by the player")]
        Weapon,

        [Description("Armor that provides protection to the player")]
        Armor,

        [Description("Consumable item like food or potions")]
        Consumable,

        [Description("A key that can unlock doors or chests")]
        Key,

        [Description("A tool used for crafting or interacting with the environment")]
        Tool,

        [Description("A resource item such as wood or stone")]
        Resource,

        [Description("Currency used for trading or purchasing items")]
        Currency
    }
}