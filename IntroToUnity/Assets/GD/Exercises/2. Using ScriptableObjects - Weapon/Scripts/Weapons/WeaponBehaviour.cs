using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private int clipSize;

    [SerializeField]
    private float range;

    [SerializeField]
    private int rank;

    [SerializeField]
    [ReadOnly]
    private bool isUpgraded;

    [SerializeField]
    [RequireInterface(typeof(IModifyWeapon))]
    private List<ScriptableObject> upgrades;

    #region Properties

    public int ClipSize { get => clipSize; set => clipSize = value; }
    public float Range { get => range; set => range = value; }
    public int Rank { get => rank; set => rank = value; }

    #endregion Properties

    #endregion Fields

    [ContextMenu("Apply Upgrade")]
    public void ApplyUpgrade()
    {
        //get a random index in the range
        var index = Random.Range(0, upgrades.Count);

        //get the upgrade at the index
        var upgrade = upgrades[index] as IModifyWeapon;

        //apply the upgrade
        upgrade.Apply(this);

        //set the upgrade flag
        isUpgraded = true;
    }

    public override string ToString()
    {
        return $"{ClipSize},{Range},{Rank}";
    }
}