using GD.Items;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "GD/Inventory")]
public class SimpleInventory : SerializedScriptableObject
{
    [SerializeField]
    public Dictionary<ItemData, int> contents = new Dictionary<ItemData, int>();

    /// <summary>
    /// Gets the count of the specified item in the inventory.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Count(ItemData item)
    {
        if (contents.ContainsKey(item))
            return contents[item];
        return 0;
    }

    /// <summary>
    /// Returns true if the inventory contains the specified item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(ItemData item)
    {
        return contents.ContainsKey(item);
    }

    /// <summary>
    /// Adds the specified amount of items to the inventory.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void Add(ItemData item, int count)
    {
        if (contents.ContainsKey(item))
            contents[item] += count;
        else
            contents.Add(item, count);
    }

    /// <summary>
    /// Removes the specified amount of items from the inventory.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public int Remove(ItemData item, int count)
    {
        if (contents.ContainsKey(item))
        {
            if (contents[item] > count)
            {
                contents[item] -= count;
                return count;
            }
            else
            {
                int removed = contents[item];
                contents.Remove(item);
                return removed;
            }
        }
        return 0;
    }

    /// <summary>
    /// Removes all items from the inventory.
    /// </summary>
    /// <returns></returns>
    public bool Clear()
    {
        contents.Clear();
        return contents.Count == 0;
    }
}