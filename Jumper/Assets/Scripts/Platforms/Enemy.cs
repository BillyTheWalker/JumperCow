using UnityEngine;

namespace Assets.Scripts.Platforms
{
    class Enemy : MonoBehaviour
    {
        private int _healthPoints;

        public int HealthPoints
        {
            get { return _healthPoints; }
            set
            {
                _healthPoints = value;
                if (_healthPoints == 0)
                    Die();
            }
        }
        private void Start()
        {

        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                Player.Instance.Die();
                return;
            }
            if (!other.gameObject.GetComponent<Platform>())
                Die();
        }
    }
}
