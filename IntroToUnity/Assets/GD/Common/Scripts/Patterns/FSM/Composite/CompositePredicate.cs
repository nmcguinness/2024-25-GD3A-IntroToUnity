using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;
using GD.Types;

namespace GD.FSM
{
    /// <summary>
    /// Composite predicate that allows combining multiple predicates using logical AND or OR operations.
    /// </summary>
    [CreateAssetMenu(menuName = "GD/FSM/Composite Predicate")]
    public class CompositePredicate : PredicateBase
    {
        [InfoBox("A composite predicate that allows combining multiple predicates using logical AND or OR operations.")]
        public ConditionType conditionType;

        [ListDrawerSettings(ShowFoldout = true), InlineEditor]
        public List<PredicateBase> conditions;

        public override bool Evaluate()
        {
            if (conditionType == ConditionType.And)
                return conditions.TrueForAll(c => c.Evaluate());
            else if (conditionType == ConditionType.Or)
                return conditions.Exists(c => c.Evaluate());
            else
                return conditions.FindAll(c => c.Evaluate()).Count == 1;
        }
    }
}