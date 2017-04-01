using System.Collections;
using Assets.Scripts.Platforms;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private bool _jumped;
        private GameObject _currentPlatform;
        public static Player Instance { get; private set; }
        [HideInInspector] public bool OnTrampoline;

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

        private void Start()
        {
            gameObject.MoveLeft();
        }

        private void Update()
        {
            if (transform.localPosition.x <= Constants.LeftBorder || transform.localPosition.y <= Constants.LowerBorder)
            {
                Die();
            }

            if (_jumped) return;

            if (Input.GetMouseButton(0))
            {
                Jump(1);
            }
            else if (Input.GetMouseButton(1) || OnTrampoline)
            {
                Jump(2);
            }
        }

        private void Jump(int distance)
        {
            LeanTween.pause(gameObject);
            OnTrampoline = false;
            _jumped = true;
            LeanTween.moveLocalX(gameObject, GetFallPosition(distance), Constants.JumpTime)
                .setOnComplete(() => { gameObject.MoveLeft(); });
            LeanTween.moveLocalY(gameObject, Constants.JumpHight, Constants.HalfJumpTime)
                .setOnComplete(() => { LeanTween.moveLocalY(gameObject, 0, Constants.HalfJumpTime); });
        }


        private float GetFallPosition(int distance)
        {
            return (_currentPlatform.transform.localPosition.x + distance*Constants.PlatformSize) -
                   GameController.Instance.MovementSpeed*Constants.JumpTime;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Platform>())
            {
                _jumped = false;
                _currentPlatform = other.gameObject;
            }
            else
            {
                Die();
            }
        }
    }
}