using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Player Rank")]
public class PlayerRankCondition : ConditionBase
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private int rankThreshold = 1000;

    protected override bool EvaluateCondition()
    {
        return player.rank >= rankThreshold;
    }
}