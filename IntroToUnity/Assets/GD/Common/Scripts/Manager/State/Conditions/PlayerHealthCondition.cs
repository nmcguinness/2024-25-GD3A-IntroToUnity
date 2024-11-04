using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Player Health")]
public class PlayerHealthCondition : ConditionBase
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private int healthThreshold = 0;

    protected override bool EvaluateCondition()
    {
        return player.health < healthThreshold;
    }
}