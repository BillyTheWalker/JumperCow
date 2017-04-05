using UnityEngine;

namespace Assets.Scripts
{
    public static class MovementBehaviour
    {
        public static void MoveLeft(this GameObject gameObject)
        {
            LeanTween.moveLocalX(gameObject, 0, GetTime(gameObject.transform.localPosition.x));
        }

        public static void MoveRight(this GameObject gameObject)
        {
            LeanTween.moveLocalX(gameObject, Constants.PlatformSpawnPoint, GetTime(Constants.PlatformSpawnPoint - gameObject.transform.localPosition.x));
        }

        public static void MoveRight(this GameObject gameObject, float speed)
        {
            LeanTween.moveLocalX(gameObject, Constants.PlatformSpawnPoint, GetTime(Constants.PlatformSpawnPoint - gameObject.transform.localPosition.x, speed));
        }

        private static float GetTime(float x)
        {
            return x / GameController.Instance.MovementSpeed;
        }

        public static void MoveLeft(this GameObject gameObject, float speed)
        {
            LeanTween.moveLocalX(gameObject, 0, GetTime(gameObject.transform.localPosition.x, speed));
        }

        private static float GetTime(float x, float speed)
        {
            return x / speed;
        }
    }
}