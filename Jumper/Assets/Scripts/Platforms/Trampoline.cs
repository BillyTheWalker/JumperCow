using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Trampoline : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
                Player.Instance.OnTrampoline = true;
        }
    }
}