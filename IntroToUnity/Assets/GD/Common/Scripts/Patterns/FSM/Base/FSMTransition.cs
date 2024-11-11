using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD.FSM
{
    /// <summary>
    /// Represents a transition between states. A transition includes a target state
    /// and a condition (predicate) that must be met to trigger the transition.
    /// </summary>
    [CreateAssetMenu(menuName = "GD/FSM/Transition")]
    public class FSMTransition : ScriptableObject
    {
        [FoldoutGroup("Transition Settings")]
        [ValueDropdown("GetAllStates"), LabelText("Target State")]
        public FSMState targetState;

        [FoldoutGroup("Transition Settings"), InlineEditor]
        public PredicateBase condition;

        private IEnumerable<FSMState> GetAllStates()
        {
            return Resources.LoadAll<FSMState>("");
        }
    }
}