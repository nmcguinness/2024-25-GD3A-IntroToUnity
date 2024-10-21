using GD.Items;
using UnityEngine;

namespace GD
{
    // Concrete implementation of BaseGameEvent that carries an int parameter.
    // Used to create an integer-based event that can be raised and responded to.
    [CreateAssetMenu(fileName = "ItemGameEvent",
        menuName = "GD/Events/Params/Item",
        order = 4)]
    public class ItemGameEvent : BaseGameEvent<ItemData>
    { }
}