using UnityEngine;

/// <summary>
/// Interface for changing the material texture
/// </summary>
public interface ISwapTexture
{
    /// <summary>
    /// Changes the texture of the material
    /// </summary>
    /// <param name="outfit"></param>
    void SwapTexture(Texture outfit);
    /// <summary>
    /// Changes the texture back to the default texture
    /// </summary>
    void SwapTexture();
}