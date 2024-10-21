using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    [ReadOnly]
    private bool isUpgraded;

    #endregion Fields
}