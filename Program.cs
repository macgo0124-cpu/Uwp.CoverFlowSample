using System;
using System.Collections.Generic;
using System.Numerics;

public class Enemy
{
    public Vector3 Position { get; set; }
}

public class CoverPoint
{
    public Vector3 Position { get; set; }
    public float ProtectionValue { get; set; }
}

public class Player
{
    public Vector3 Position { get; set; }
    public Vector3 AimDirection { get; set; }

    // Aim Assist
    public void AimAssist(Enemy target, float strength)
    {
        if (target == null)
            return;

        strength = Math.Clamp(strength, 0f, 1f);

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
        if (covers == null || covers.Count == 0 || enemy == null)
            return null;

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
}

class Program
{
    static void Main()
    {
        Player player = new Player
        {
            Position = new Vector3(0, 0, 0),
            AimDirection = Vector3.UnitX
        };

        Enemy enemy = new Enemy
        {
            Position = new Vector3(10, 0, 5)
        };

        player.AimAssist(enemy, 0.25f);

        List<CoverPoint> covers = new()
        {
            new CoverPoint
            {
                Position = new Vector3(5,0,0),
                ProtectionValue = 0.8f
            },
            new CoverPoint
            {
                Position = new Vector3(8,0,2),
                ProtectionValue = 1.0f
            },
            new CoverPoint
            {
                Position = new Vector3(2,0,1),
                ProtectionValue = 0.6f
            }
        };

        CoverPoint bestCover =
            player.FindBestCover(covers, enemy);

        if (bestCover != null)
        {
            Console.WriteLine(
                $"Best cover: {bestCover.Position}"
            );
        }
    }
}