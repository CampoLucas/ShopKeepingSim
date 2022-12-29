using UnityEngine;

public class CmdSwapTexture : ICommand
{
    private SpriteRenderer _sprite;
    private Texture _texture;
    private Texture _lastTexture;
    private static readonly int MainTex = Shader.PropertyToID("_Main_Tex");

    public CmdSwapTexture(SpriteRenderer renderer, Texture texture)
    {
        _sprite = renderer;
        _texture = texture;
        _lastTexture = _sprite.material.GetTexture(MainTex);
    }
    
    public void Do()
    {
        _sprite.material.SetTexture(MainTex, _texture);
    }

    public void Undo()
    {
        _sprite.material.SetTexture(MainTex, _lastTexture);
    }
}