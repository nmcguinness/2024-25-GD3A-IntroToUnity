using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/Stats/Mortar")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string name;

    [SerializeField]
    private WeaponType type = WeaponType.Handgun;

    [SerializeField]
    private int clipSize;

    [SerializeField]
    private float range;

    [SerializeField]
    private int rank;

    public string Name { get => name; set => name = value; }
    public int ClipSize { get => clipSize; set => clipSize = value; }
    public float Range { get => range; set => range = value; }
    public int Rank { get => rank; set => rank = value; }

    public override string ToString()
    {
        return $"{ClipSize},{Range},{Rank}";
    }
}