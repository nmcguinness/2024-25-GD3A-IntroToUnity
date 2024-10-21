/// <summary>
/// Used by ScriptableObjects that modify a weapon
/// </summary>
public interface IModifyWeapon
{
    void Apply(WeaponData w);
}