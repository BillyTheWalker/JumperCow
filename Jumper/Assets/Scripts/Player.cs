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
        public float JumpTime = Constants.JumpTime;

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

            if (Input.GetMouseButton(0) && !OnTrampoline)
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
            var jumpTime = JumpTime;
            LeanTween.pause(gameObject);
            OnTrampoline = false;
            _jumped = true;
            LeanTween.moveLocalX(gameObject, GetFallPosition(distance), jumpTime)
                .setOnComplete(() => { gameObject.MoveLeft(); });
            LeanTween.moveLocalY(gameObject, Constants.JumpHight, jumpTime / 2)
                .setOnComplete(() => { LeanTween.moveLocalY(gameObject, 0, jumpTime / 2); });
        }


        private float GetFallPosition(int distance)
        {
            return (_currentPlatform.transform.localPosition.x + distance * Constants.PlatformSize) -
                   GameController.Instance.MovementSpeed * JumpTime;
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