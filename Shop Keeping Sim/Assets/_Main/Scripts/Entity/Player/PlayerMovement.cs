using UnityEngine;

/// <summary>
/// As the name suggests, is the class that makes the player move
/// uses command to move
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour, IMovement
{
    private PlayerSO _stats;
    private Invoker _invoker = new();

    private void Awake()
    {
        _stats = GetComponent<Player>().GetData();
    }

    /// <summary>
    /// Moves the player using transform
    /// </summary>
    /// <param name="dir"></param>
    public void Move(Vector2 dir)
    {
        var move = new CmdMove(transform, dir, _stats.Speed);
        _invoker.AddCommand(move);
    }
}
