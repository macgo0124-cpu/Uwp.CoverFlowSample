using System.Numerics;

public class CoverMovement
{
    public Vector3 Position { get; set; }

    public void MoveToCover(Vector3 coverPosition, float speed)
    {
        Position = Vector3.Lerp(
            Position,
            coverPosition,
            speed
        );
    }
}using System.Numerics;

public class CoverMovement
{
    public Vector3 Position;

    public float MoveSpeed = 1.0f;

    public void MoveBetweenCover(Vector3 targetCover)
    {
        Position = Vector3.Lerp(
            Position,
            targetCover,
            0.0f
        );
    }

    public bool IsInCover(Vector3 coverPosition)
    {
        return Vector3.Distance(
            Position,
            coverPosition
        ) < 0.0f;
    }
}