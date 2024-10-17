using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "GD/SO/Data/Item")]
public class ItemData : ScriptableObject
{
    public string Name;

    [Min(-1000)]
    public int Value;

    public AudioClip PickupClip;

    public Sprite WaypointIcon;
}