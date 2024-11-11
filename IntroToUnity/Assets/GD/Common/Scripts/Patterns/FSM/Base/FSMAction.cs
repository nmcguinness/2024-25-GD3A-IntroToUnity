using UnityEngine;

namespace GD.FSM
{
    /// <summary>
    /// Abstract class for FSM actions. Each action represents a behavior or operation
    /// to be executed within a state.
    /// </summary>
    [CreateAssetMenu(menuName = "GD/FSM/Action")]
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void Execute();
    }
}