using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;
using GD.Types;

namespace GD.FSM
{
    /// <summary>
    /// Represents a state in the finite state machine. Each state contains actions
    /// to be executed upon entering or exiting the state, as well as transitions
    /// to other states based on conditions.
    /// </summary>
    [CreateAssetMenu(menuName = "GD/FSM/State")]
    public class FSMState : ScriptableGameObject
    {
        [FoldoutGroup("Basic Info"), LabelText("State Name")]
        public string stateName;

        [FoldoutGroup("Actions")]
        [HorizontalGroup("ActionsGroup", Width = 0.5f)]
        public List<FSMAction> enterActions;

        [FoldoutGroup("Actions")]
        [HorizontalGroup("ActionsGroup", Width = 0.5f)]
        public List<FSMAction> exitActions;

        [FoldoutGroup("Actions")]
        public List<FSMAction> actions;

        [FoldoutGroup("Transitions")]
        public List<FSMTransition> transitions;
    }
}