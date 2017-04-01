using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        private readonly PlatformTypes[] _lastPlatformTypes = new PlatformTypes[2];

        private readonly Random _random = new Random();

        private Sprite[] _platforms;

        public GameObject Platform;
        public static PlatformController Instance { get; private set; }

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
            GetPlatformSprites();
            for (var i = Constants.LeftBorder; i < Constants.PlatformSpawnPoint; i += Constants.PlatformSize)
                SpawnPlatforms(i, PlatformTypes.Simple);
        }

        private void GetPlatformSprites()
        {
            _platforms = Resources.LoadAll<Sprite>(Constants.SpritesFolder);
        }

        public void SpawnPlatforms()
        {
            UpdateLastPlatforms();
            var platform = MainSpawnPlatform(Constants.PlatformSpawnPoint);
            SetSprite(platform);
            SetAdditionalFeatures(platform);
        }

        private void SpawnPlatforms(float positionX, PlatformTypes platformType)
        {
            var platform = MainSpawnPlatform(positionX);
            platform.GetComponent<SpriteRenderer>().sprite = _platforms[(int) platformType];
        }

        private GameObject MainSpawnPlatform(float positionX)
        {
            var platform = Instantiate(Platform);
            platform.transform.parent = gameObject.transform;
            platform.transform.localPosition = new Vector3(positionX, Constants.PlatformPositionY);
            platform.AddComponent<Platform>();
            return platform;
        }

        private void SetAdditionalFeatures(GameObject platform)
        {
            switch (_lastPlatformTypes[0])
            {
                case PlatformTypes.Dissapearing:
                    platform.AddComponent<DissapearingPlatform>();
                    break;
                case PlatformTypes.Trampoline:
                    platform.AddComponent<Trampoline>();
                    break;
                case PlatformTypes.Freezing:
                    platform.AddComponent<Freezing>();
                    break;
                case PlatformTypes.Carton:
                case PlatformTypes.Empty:
                    //todo
                    break;
            }
        }

        private void UpdateLastPlatforms()
        {
            var index = GetAvailablePlatformIndex();
            _lastPlatformTypes[1] = _lastPlatformTypes[0];
            _lastPlatformTypes[0] = (PlatformTypes) index;
        }

        private int GetAvailablePlatformIndex()
        {
            if (_lastPlatformTypes[0] != PlatformTypes.Empty && _lastPlatformTypes[0] != PlatformTypes.Carton &&
                _lastPlatformTypes[1] != PlatformTypes.Trampoline)
                if (_random.NextDouble() < Constants.EmptyPlatformChance)
                    return Constants.PlatformsNumber;
            if (_random.NextDouble() < Constants.SimplePlatformChance)
                return 0;
            var index = _random.Next(1, Constants.PlatformsNumber);
            if (index == (int) PlatformTypes.Empty || index == (int) PlatformTypes.Carton)
                index = GetAvailablePlatformIndex();
            return index;
        }

        private void SetSprite(GameObject platform)
        {
            if ((int) _lastPlatformTypes[0] >= _platforms.Length)
            {
                platform.GetComponent<SpriteRenderer>().sprite = null;
                return;
            }
            platform.GetComponent<SpriteRenderer>().sprite = _platforms[(int) _lastPlatformTypes[0]];
        }
    }
}