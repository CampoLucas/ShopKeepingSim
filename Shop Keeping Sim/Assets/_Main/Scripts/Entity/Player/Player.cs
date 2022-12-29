using UnityEngine;

/// <summary>
/// The class player uses facade structure and strategy
/// </summary>
public class Player : Character
{
    private PlayerInputs _inputs;private IInteraction _interaction;
    private ISwapTexture _swapOutfit;

    protected override void Awake()
    {
        base.Awake();
        _inputs = GetComponent<PlayerInputs>();
        _interaction = GetComponent<IInteraction>();
        _swapOutfit = GetComponent<ISwapTexture>();
    }

    private void Start()
    {
        if (!_inputs) return;
        _inputs.OnMovement += Move;
        _inputs.OnInteraction += Interact;
    }
    
    private void OnDisable()
    {
        if (!_inputs) return;
        _inputs.OnMovement -= Move;
        _inputs.OnInteraction -= Interact;
    }

    private void Update()
    {
        if (Animation & _inputs) Animation.MovementAnimation(_inputs.MoveDir);
    }

    private void Interact()
    {
        _interaction?.Interact();
    }

    /// <summary>
    /// Changes the players outfit
    /// </summary>
    /// <param name="outfit"> A sprite sheet of the player with an outfit </param>
    public void ChangeOutfit(Texture outfit) => _swapOutfit?.SwapTexture(outfit);
    /// <summary>
    /// Changes back to the default sprite sheet of the player
    /// </summary>
    public void ChangeOutfit() => _swapOutfit?.SwapTexture();
    /// <summary>
    /// Used to disable the players inputs
    /// </summary>
    /// <param name="canUseInputs"></param>
    public void EnableInputs(bool canUseInputs) => _inputs.EnableInputs(canUseInputs);
}
