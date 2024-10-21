using GD.Types;
using UnityEngine;

namespace GD.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "GD/Data/Item")]
    public class ItemData : ScriptableGameObject
    {
        #region Fields

        [SerializeField]
        [Tooltip("The category of item")]
        private ItemCategoryType itemCategory = ItemCategoryType.Consumable;

        [SerializeField]
        [Tooltip("The type of item")]
        private ItemType itemType = ItemType.Resource;

        [Header("UI & Sound")]
        [SerializeField]
        private Sprite uiIcon;

        [SerializeField]
        private AudioClip audioClip;

        #endregion Fields

        #region Properties

        public ItemCategoryType ItemCategory { get => itemCategory; set => itemCategory = value; }
        public ItemType ItemType { get => itemType; set => itemType = value; }

        public Sprite UiIcon { get => uiIcon; set => uiIcon = value; }
        public AudioClip AudioClip { get => audioClip; set => audioClip = value; }

        #endregion Properties
    }
}