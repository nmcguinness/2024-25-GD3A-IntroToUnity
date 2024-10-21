using GD;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private SerializableDictionary upgradeDictionary;

    [SerializeField]
    [RequireInterface(typeof(IModifyWeapon))]
    private List<ScriptableObject> upgrades;

    private void Awake()
    {
        upgradeDictionary = new SerializableDictionary();
    }

    //Listen for upgrade event (weapondata)

    //Apply upgrade to the weapon data
    [ContextMenu("Apply Upgrade")]
    public void ApplyUpgrade(WeaponData w)
    {
        //upgrade once
        //get a random index in the range
        var index = Random.Range(0, upgrades.Count);

        //get the upgrade at the index
        var upgrade = upgrades[index] as IModifyWeapon;

        //apply the upgrade
        upgrade.Apply(w);
    }
}