using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class DissapearingPlatform : MonoBehaviour
    {
        private void Dissapear()
        {
            if (GetComponent<SpriteRenderer>().sprite != null)
                GetComponent<SpriteRenderer>().sprite = null;
            gameObject.AddComponent<EmptyPlatform>();
        }

        private IEnumerator ThisCoroutine()
        {
            yield return new WaitForSeconds(Constants.ActionTime);
            Dissapear();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            StartCoroutine(ThisCoroutine());
        }
    }
}