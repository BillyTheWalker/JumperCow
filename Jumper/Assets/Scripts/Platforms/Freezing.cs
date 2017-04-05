using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Freezing : MonoBehaviour
    {
        private float _freezedJumpTime = Constants.JumpTime + Constants.FreezeEffect;


        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.GetComponent<Player>()) return;
            if (Player.Instance.JumpTime == _freezedJumpTime) return;
            Player.Instance.JumpTime = _freezedJumpTime;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.GetComponent<Player>()) return;
            FreezController.Instance.Freeze();
        }

    }
}