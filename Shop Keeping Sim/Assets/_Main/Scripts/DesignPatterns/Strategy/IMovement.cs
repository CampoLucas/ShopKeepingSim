using UnityEngine;

/// <summary>
/// This interface makes sure all movement classes have a method called move with the direction it is moving
/// </summary>
public interface IMovement
{
    /// <summary>
    /// Moves in a direction
    /// </summary>
    /// <param name="dir">direction</param>
    void Move(Vector2 dir);
}
