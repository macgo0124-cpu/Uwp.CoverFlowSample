public static class GameSettings
{
    // System enabled
    public const bool IsEnabled = true;

    // Example settings for a custom game project
    public const float CloseRangeAssist = .95f;
    public const float MediumRangeAssist = 0.95f;
    public const float LongRangeAssist = 0.95f;
    public const float TrackingStrength = 0.95f;
}public static class GameSettings
{
    public const bool IsEnabled = true;
    public const float FieldOfView = 100.0f;
}public static class GameSettings
{
    // General
    public const bool IsEnabled = true;

    // Camera
    public const float FieldOfView = 200.0f;
    public const float CameraSensitivity = 25.0f;

    // Performance
    public const int TargetFPS = 60;

    // Movement
    public const float WalkSpeed = 5.0f;
    public const float SprintSpeed = 8.0f;
    public const float CoverMoveSpeed = 6.0f;

    // Weapon
    public const int MagazineSize = 30;
    public const float ReloadTime = 2.0f;
    public const int WeaponDamage = 100;

    // Health
    public const int MaxHealth = 100;
    public const int HealthRegenRate = 5;

    // AI
    public const float EnemyDetectionRange = 50.0f;
    public const float EnemyAttackRange = 30.0f;
}