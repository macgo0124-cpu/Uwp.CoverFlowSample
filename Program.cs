// Simple Aim Assist
public void AimAssist(Enemy target, float strength)
{
    Vector3 desiredDirection =
        Vector3.Normalize(target.Position - Position);

    AimDirection = Vector3.Lerp(
        AimDirection,
        desiredDirection,
        strength
    );

    Console.WriteLine("Aim Assist activated.");
}

// Best Cover Selection
public CoverPoint FindBestCover(
    List<CoverPoint> covers,
    Enemy enemy)
{
    CoverPoint bestCover = null;
    float bestScore = float.MinValue;

    foreach (var cover in covers)
    {
        float distanceToPlayer =
            Vector3.Distance(Position, cover.Position);

        float distanceToEnemy =
            Vector3.Distance(enemy.Position, cover.Position);

        float score =
            (cover.ProtectionValue * 100f)
            + (distanceToEnemy * 0.5f)
            - (distanceToPlayer * 0.3f);

        if (score > bestScore)
        {
            bestScore = score;
            bestCover = cover;
        }
    }

    return bestCover;
}