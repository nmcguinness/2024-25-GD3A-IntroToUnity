using UnityEngine;

[CreateAssetMenu(fileName = "WeaponRangeModify",
    menuName = "SO/Modify/Weapon/Range")]
public class WeaponRangeModify : ScriptableObject, IModifyWeapon
{
    [SerializeField]
    [Tooltip("Description of the upgrade")]
    private string description = "Add description...";

    [SerializeField]
    [Tooltip("Multiplier to apply to the weapon's range (can reduce to 10% at minimum")]
    [Range(0.1f, 10)]
    public float rangeMultiplier = 1;

    public void Apply(WeaponData w)
    {
        w.Range *= rangeMultiplier;
    }
}