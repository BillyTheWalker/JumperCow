using Assets.Scripts.Platforms;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public float MovementSpeed = 5;


        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if (Player.Instance == null) return;
            var playerPosition = Player.Instance.gameObject.transform.localPosition;
            if (playerPosition.x > Constants.ComplicationDistance && MovementSpeed < Constants.MaxSpeed && !Player.Instance.Jumped)
            {
                ChangeSpeed(Constants.ComplicationValue);
            }
            if (playerPosition.x < Constants.ReliefDistance && MovementSpeed > Constants.MinSpeed && !Player.Instance.Jumped)
            {
                ChangeSpeed(-Constants.ComplicationValue);
            }

        }

        private void ChangeSpeed(float change)
        {
            MovementSpeed += change;
            PlatformController.Instance.RefreshMovement();
            Player.Instance.gameObject.Refresh();
        }
    }
}