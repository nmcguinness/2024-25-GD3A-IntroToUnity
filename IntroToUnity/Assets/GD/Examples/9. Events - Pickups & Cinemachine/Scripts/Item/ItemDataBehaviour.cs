using UnityEngine;

public class ItemDataBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    public ItemData ItemData { get => itemData; protected set => itemData = value; }
}