using UnityEngine;

namespace GD.State
{
    [CreateAssetMenu(menuName = "GD/Conditions/Player Has Hero")]
    public class PlayerHasHeroCondition : ConditionBase
    {
        protected override bool EvaluateCondition(ConditionContext context)
        {
            return context.player.hasHeroObject;
        }
    }
}