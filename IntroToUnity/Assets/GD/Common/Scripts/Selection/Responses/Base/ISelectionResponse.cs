using UnityEngine;

namespace GD.Selection
{
    public interface ISelectionResponse
    {
        void OnSelect(Transform currentTransform);

        void OnDeselect(Transform currentTransform);
    }
}