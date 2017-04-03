using System.Collections;
using UnityEngine;
using Random = System.Random;


namespace Assets.Scripts
{
    public class CloudController : MonoBehaviour
    {
        public GameObject Cloud;
        private readonly Random _random = new Random();

        private void Start()
        {
            gameObject.MoveLeft(_random.Next(Constants.CloudMinSpeed, Constants.CloudMaxSpeed));
            StartCoroutine(CloudSpawner());
        }

        private void Update()
        {
            if (!(transform.localPosition.x <= 0)) return;
            Destroy(gameObject);
        }

        public void CreateCloud()
        {
            var cloud = Instantiate(Cloud);
            var scale = _random.Next(1, Constants.CloudMaxScale);
            cloud.transform.localScale = new Vector3(scale, scale);
            cloud.transform.parent = transform.parent;
            cloud.transform.localPosition = new Vector3(Constants.PlatformSpawnPoint, _random.Next(Constants.CloudsLower, Constants.CloudsUpper), -scale);
        }

        private IEnumerator CloudSpawner()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(Constants.CloudMinSpawnDelay, Constants.CloudMaxSpawnDelay));
            CreateCloud();
        }
    }
}