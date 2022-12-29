using UnityEngine;

/// <summary>
/// The method of changing clothes is by swapping the texture of the material
/// </summary>
[RequireComponent(typeof(Player))]
public class SwapOutfits : MonoBehaviour, ISwapTexture
{
    private SpriteRenderer _sprite;
    private StatsSO _stats;
    private Invoker _invoker = new();

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _stats = GetComponent<Character>().GetData();
    }

    private void Start()
    {
        SwapTexture(_stats.DefaultTexture);
    }

    /// <summary>
    /// Changes the texture property in the sprite
    /// </summary>
    /// <param name="outfit"></param>
    public void SwapTexture(Texture outfit)
    {
        var swap = new CmdSwapTexture(_sprite, outfit);
        _invoker.AddCommand(swap);
    }
    /// <summary>
    /// Changes back to the default outfit
    /// </summary>
    public void SwapTexture() => SwapTexture(_stats.DefaultTexture);
}
