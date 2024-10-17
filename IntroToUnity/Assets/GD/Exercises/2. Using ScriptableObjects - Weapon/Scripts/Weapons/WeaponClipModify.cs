using UnityEngine;

[CreateAssetMenu(fileName = "WeaponClipModify",
    menuName = "SO/Modify/Weapon/Range")]
public class WeaponClipModify : ScriptableObject, IModifyWeapon
{
    [SerializeField]
    [Tooltip("Description of the upgrade")]
    private string description = "Add description...";

    [SerializeField]
    [Tooltip("Multiplier to apply to the weapon's range (can reduce to 10% at minimum")]
    [Range(0.1f, 10)]
    public float multiplier = 1;

    public void Apply(WeaponBehaviour w)
    {
        w.Range *= multiplier;
    }
}