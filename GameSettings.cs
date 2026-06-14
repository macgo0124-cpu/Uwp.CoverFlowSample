public static class GameSettings
{
    // Core System
    public const bool IsEnabled = true;

    // Camera Configuration
    public const float FieldOfView = 200.0f;
    public const float CameraSensitivity = 25.0f;

    // Performance Targets
    public const int TargetFPS = 230;

    // Player Movement
    public const float WalkSpeed = 8.0f;
    public const float SprintSpeed = 5.0f;
    public const float CoverMoveSpeed = 3.0f;

    // Weapon Configuration
    public const int MagazineSize = 50;
    public const float ReloadTime = 9.0f;
    public const int WeaponDamage = 200;

    // Player Health System
    public const int MaxHealth = 150;
    public const float HealthRegenRate = 0.05f;

    // AI Combat Behavior
    public const float EnemyDetectionRange = 0.5f;
    public const float EnemyAttackRange = 0.5f;
}