using UnityEngine;

namespace Assets.Scripts
{
    public static class MovementBehaviour
    {
        public static void MoveLeft(this GameObject gameObject)
        {
            LeanTween.moveLocalX(gameObject, 0, GetTime(gameObject.transform.localPosition.x));
        }

        private static float GetTime(float x)
        {
            return x/GameController.Instance.MovementSpeed;
        }
    }
}