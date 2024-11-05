using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Team Gem")]
public class TeamGemCondition : ConditionBase
{
    //[SerializeField]
    //private List<Player> playerList;

    [SerializeField]
    private float avgRankForPromotion = 25;

    protected override bool EvaluateCondition(ConditionContext context)
    {
        return false;
    }
}