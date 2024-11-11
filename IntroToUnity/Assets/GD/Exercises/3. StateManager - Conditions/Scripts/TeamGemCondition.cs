using GD.State;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Team Gem")]
public class TeamGemCondition : ConditionBase
{
    [SerializeField]
    private float avgRankForPromotion = 25;

    protected override bool EvaluateCondition(ConditionContext conditionContext)
    {
        //if looking through each player inventory
        //then exit for loop when we find "magic gem" in one inventory
        //return true;

        //var average = 0;
        //foreach (Player player in playerList)
        //    average += player.rank;

        //average /= playerList.Count;

        //return average >= avgRankForPromotion;

        return false;
    }
}