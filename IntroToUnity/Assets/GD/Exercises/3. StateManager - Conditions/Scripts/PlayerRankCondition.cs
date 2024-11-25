using GD.Exercises;
using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Player Rank")]
public class PlayerRankCondition : ConditionBase
{
    [SerializeField]
    private int rankThreshold = 1000;

    protected override bool EvaluateCondition(ConditionContext conditionContext)
    {
        // singleton pattern - BAD!!!!
        // return PlayerSingleton.rank >= rankThreshold;

        // dependency injection - GOOD!!!!
        return conditionContext.Player.rank >= rankThreshold;
    }
}