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
}