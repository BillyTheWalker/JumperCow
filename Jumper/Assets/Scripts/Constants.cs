namespace Assets.Scripts
{
    public class Constants
    {
        public const string PlatformSpritesFolder = "Sprites/Platforms",
            BulletsSpritesFolder = "Sprites/lines",
            EnemiesSpriteFolder = "sprites/monster";

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
            CloudMaxSpeed = 10,
            BulletSpeed = 7;

        public const float JumpTime = .5f,
            HalfJumpTime = .25f,
            TimeToDissapear = 1f,
            FreezeTime = 2f,
            FreezeEffect = .5f,
            JumpLength = 2.5f,
            PlatformPositionY = -3f,
            CloudMinSpawnDelay = .2f,
            CloudMaxSpawnDelay = 1f,
            BulletOffsetX = .1f,
            BulletOffsetY = .45f,
            FlyingEnemyY = -.8f,
            SimpleEnemyY = -1.4f;

        public const double EmptyPlatformChance = .2,
            SimplePlatformChance = .5,
            EnemySpawnChance = .05;
    }
}