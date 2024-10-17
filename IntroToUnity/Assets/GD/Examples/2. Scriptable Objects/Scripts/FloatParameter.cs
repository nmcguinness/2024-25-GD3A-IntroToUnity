using UnityEngine;

[CreateAssetMenu(fileName = "FloatParameter",
            menuName = "SO/Float")]
public class FloatParameter : ScriptableObject
{
    public string description;
    public float value;
}