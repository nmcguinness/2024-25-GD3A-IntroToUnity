/// <summary>
/// The type of weapon that a player can use.
/// Use when we have a limited set of ....
/// </summary>
public enum WeaponType : sbyte  //sbyte range is 0 - 255, byte range is -127 to 127
{
    Handgun = 0,
    Grenade = 1,
    Rifle = 2,
    Mortar = 3
}