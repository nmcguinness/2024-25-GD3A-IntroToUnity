using UnityEngine;
using UnityEngine.Events;

namespace GD
{
    [AddComponentMenu("GD/Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        private string description;

        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private GameEvent Event;

        [SerializeField]
        private UnityEvent Response; //list of functions to call when the event is raised

        private void OnEnable() => Event.RegisterListener(this);

        private void OnDisable() => Event.UnregisterListener(this);

        public virtual void OnEventRaised() => Response?.Invoke();
    }
}