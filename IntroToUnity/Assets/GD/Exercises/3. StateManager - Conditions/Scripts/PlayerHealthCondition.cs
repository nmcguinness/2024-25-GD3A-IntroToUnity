using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Player Health")]
public class PlayerHealthCondition : ConditionBase
{
    [SerializeField]
    private int healthThreshold = 0;

    protected override bool EvaluateCondition(ConditionContext conditionContext)
    {
        return conditionContext.Player.health < healthThreshold;
    }
}