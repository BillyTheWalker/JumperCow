using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Platform : MonoBehaviour
    {
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