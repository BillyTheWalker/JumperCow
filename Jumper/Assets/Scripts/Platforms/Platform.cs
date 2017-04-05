using System;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Platform : MonoBehaviour, IMyFirstInterface
    {
        public void RefreshMovement()
        {
            gameObject.Refresh();
        }

        private void Awake()
        {
            gameObject.MoveLeft();
        }

        private void Update()
        {
            if (!(transform.localPosition.x <= 0)) return;
            PlatformController.Instance.SpawnPlatforms();
            Destroy(gameObject);
        }        
    }
}