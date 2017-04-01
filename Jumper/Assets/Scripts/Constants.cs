namespace Assets.Scripts
{
    public class Constants
    {
        public const string SpritesFolder = "Sprites/Platforms";

        public const int StartPoint = -11,
            PlatformSize = 5,
            JumpHight = 2,
            LeftBorder = 0,
            RightBorder = 75,
            LowerBorder = -5,
            PlatformsNumber = 5,
            PlatformSpawnPoint = 80;

        public const float JumpTime = .5f,
            HalfJumpTime = .25f,
            ActionTime = 1f,
            JumpLength = 2.5f,
            PlatformPositionY = -2.5f;

        public const double EmptyPlatformChance = .2,
            SimplePlatformChance = .5;
    }
}