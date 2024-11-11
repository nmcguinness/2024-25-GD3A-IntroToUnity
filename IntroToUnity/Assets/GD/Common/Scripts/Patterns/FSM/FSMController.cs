using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;

namespace GD.FSM
{
    /// <summary>
    /// Controls the FSM behavior by managing the current state, executing actions,
    /// and handling state transitions based on defined conditions.
    /// </summary>
    public class FSMController : MonoBehaviour
    {
        [FoldoutGroup("FSM Settings"), InlineEditor]
        public FSMState initialState;

        [FoldoutGroup("FSM Settings"), InlineEditor]
        public List<FSMTransition> globalTransitions;

        [FoldoutGroup("Runtime Info")]
        public FSMState currentState;

        private void Start()
        {
            currentState = initialState;
        }

        private void Update()
        {
            if (!CheckGlobalTransitions())
            {
                ExecuteActions();
                CheckTransitions();
            }
        }

        private void ExecuteActions()
        {
            foreach (FSMAction action in currentState.actions)
            {
                action.Execute();
            }
        }

        private void CheckTransitions()
        {
            foreach (FSMTransition transition in currentState.transitions)
            {
                if (transition.condition.Evaluate())
                {
                    currentState = transition.targetState;
                    break;
                }
            }
        }

        private bool CheckGlobalTransitions()
        {
            foreach (var transition in globalTransitions)
            {
                if (transition.condition.Evaluate())
                {
                    currentState = transition.targetState;
                    return true;
                }
            }
            return false;
        }
    }
}