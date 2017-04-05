using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public interface IMyFirstInterface : IEventSystemHandler
    {
        void RefreshMovement();
    }
}
