using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Freezing : MonoBehaviour
    {
        private float _freezedJumpTime = Constants.JumpTime + Constants.FreezeEffect;
        private string _freeze = "Freeze";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Player.Instance.JumpTime == _freezedJumpTime) return;
            Player.Instance.JumpTime = _freezedJumpTime;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            StopCoroutine(_freeze);
            StartCoroutine(_freeze);
        }

        private IEnumerator Freeze()
        {
            yield return new WaitForSeconds(Constants.FreezeTime);
            Player.Instance.JumpTime = Constants.JumpTime;
        }
    }
}