using System;
using System.Collections.Generic;
using System.Numerics;

namespace GearsStyleAI
{
    public class CoverPoint
    {
        public Vector3 Position;
        public float ProtectionValue;

        public CoverPoint(Vector3 position, float protectionValue)
        {
            Position = position;
            ProtectionValue = protectionValue;
        }
    }

    public class Enemy
    {
        public Vector3 Position;

        public Enemy(Vector3 position)
        {
            Position = position;
        }
    }

    public class Player
    {
        public Vector3 Position;
        public Vector3 AimDirection;

        public Player(Vector3 position)
        {
            Position = position;
        }

        // Aim Assist simple
        public void AimAssist(Enemy target, float strength)
        {
            Vector3 desiredDirection =
                Vector3.Normalize(target.Position - Position);

            AimDirection = Vector3.Lerp(
                AimDirection,
                desiredDirection,
                strength
            );

            Console.WriteLine("Aim Assist activado.");
        }

        // Selección de mejor cobertura
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
    }

    class Program
    {
        static void Main()
        {
            Player player = new Player(new Vector3(0, 0, 0));
            Enemy enemy = new Enemy(new Vector3(20, 0, 15));

            List<CoverPoint> covers = new List<CoverPoint>()
            {
                new CoverPoint(new Vector3(5,0,5), 0.8f),
                new CoverPoint(new Vector3(10,0,8), 0.9f),
                new CoverPoint(new Vector3(15,0,10), 0.7f)
            };

            player.AimDirection = new Vector3(1, 0, 0);

            // AIM ASSIST
            player.AimAssist(enemy, 0.95f);

            // MEJOR COBERTURA
            CoverPoint bestCover =
                player.FindBestCover(covers, enemy);

            Console.WriteLine(
                $"Mejor cobertura: {bestCover.Position}"
            );
        }
    }
}