using GD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GD.Common.Scripts.Patterns.Events.Multi_parameter.Types.Interactable
{
    // Concrete implementation of BaseGameEvent that carries an int parameter.
    // Used to create an integer-based event that can be raised and responded to.
    [CreateAssetMenu(fileName = "InteractableGameEvent",
        menuName = "GD/SO/Events/Interactable",
        order = 4)]
    public class InteractableGameEvent : BaseGameEvent<InteractableData>
    { }
}