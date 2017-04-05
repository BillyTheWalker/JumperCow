using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    class FreezController : MonoBehaviour
    {
        public static FreezController Instance { get; private set; }
        private string _freeze = "FreezeRoutine";
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

        public void Freeze()
        {
            StopCoroutine(_freeze);
            StartCoroutine(_freeze);
        }

        private IEnumerator FreezeRoutine()
        {
            yield return new WaitForSeconds(Constants.FreezeTime);
            Player.Instance.JumpTime = Constants.JumpTime;
        }

    }
}
