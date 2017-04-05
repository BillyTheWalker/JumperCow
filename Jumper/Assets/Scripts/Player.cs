using System.Collections;
using Assets.Scripts.Platforms;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private readonly Random _random = new Random();
        private Sprite[] _bullets;
        public bool Jumped { get; private set; }
        private bool _canShot = true;
        private GameObject _currentPlatform;
        public static Player Instance { get; private set; }
        [HideInInspector]
        public bool OnTrampoline;
        [HideInInspector]
        public float JumpTime = Constants.JumpTime;
        public GameObject Bullet;

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
            _bullets = Resources.LoadAll<Sprite>(Constants.BulletsSpritesFolder);
        }

        private void Start()
        {
            gameObject.MoveLeft();
        }

        private void Update()
        {
            if (transform.localPosition.x <= Constants.LeftBorder)
            {
                Die();
            }

            if (Input.GetKeyDown(KeyCode.Space) && _canShot)
            {
                Shot();
            }

            if (Jumped) return;

            if (Input.GetMouseButtonDown(0) && !OnTrampoline)
            {
                Jump(1);
            }
            else if (Input.GetMouseButtonDown(1) || OnTrampoline)
            {
                Jump(2);
            }
        }

        private void Jump(int distance)
        {
            var jumpTime = JumpTime;
            LeanTween.pause(gameObject);
            OnTrampoline = false;
            Jumped = true;
            LeanTween.moveLocalX(gameObject, GetFallPosition(distance), jumpTime)
                .setOnComplete(() => { gameObject.MoveLeft(); });
            LeanTween.moveLocalY(gameObject, transform.localPosition.y + Constants.JumpHight, jumpTime / 2)
                .setOnComplete(() => { LeanTween.moveLocalY(gameObject, transform.localPosition.y - Constants.JumpHight, jumpTime / 2).setOnComplete(() => { Jumped = false; }); });
        }


        private float GetFallPosition(int distance)
        {
            return (_currentPlatform.transform.localPosition.x + distance * Constants.PlatformSize) -
                   GameController.Instance.MovementSpeed * JumpTime;
        }

        private void Shot()
        {
            var position = transform.localPosition;
            var bullet = Instantiate(Bullet);
            bullet.transform.parent = transform.parent;
            bullet.GetComponent<SpriteRenderer>().sprite = _bullets[_random.Next(_bullets.Length)];
            bullet.transform.localPosition = new Vector3(position.x + Constants.BulletOffsetX, position.y + Constants.BulletOffsetY);
            bullet.MoveRight(Constants.BulletSpeed*5);
            StartCoroutine(BulletLifetime(bullet));
            StartCoroutine(ShotDelay());
        }

        private IEnumerator ShotDelay()
        {
            _canShot = false;
            yield return new WaitForSeconds(Constants.ShotDelay);
            _canShot = true;
        }

        private IEnumerator BulletLifetime(GameObject bullet)
        {
            yield return new WaitForSeconds(5);
            if (bullet) Destroy(bullet);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Platform>())
                _currentPlatform = other.gameObject;
        }
    }
}