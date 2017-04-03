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
            PlatformSpawnPoint = 80,
            CloudsLower = 10,
            CloudsUpper = 27,
            CloudMaxScale = 4,
            CloudMinSpeed = 2,
            CloudMaxSpeed = 10;

        public const float JumpTime = .5f,
            HalfJumpTime = .25f,
            TimeToDissapear = 1f,
            FreezeTime = 2f,
            FreezeEffect = .5f,
            JumpLength = 2.5f,
            PlatformPositionY = -3f,
            CloudMinSpawnDelay = .2f,
            CloudMaxSpawnDelay = 1f;

        public const double EmptyPlatformChance = .2,
            SimplePlatformChance = .5;
    }
}