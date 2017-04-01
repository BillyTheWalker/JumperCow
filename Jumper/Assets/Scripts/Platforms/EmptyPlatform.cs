using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class EmptyPlatform : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
                Player.Instance.Die();
        }
    }
}