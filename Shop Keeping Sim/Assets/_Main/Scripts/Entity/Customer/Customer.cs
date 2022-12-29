using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Character, IInteractable
{
    private IInteractable _interaction;

    protected override void Awake()
    {
        base.Awake();
        _interaction = GetComponent<IInteractable>();
    }

    public void Interacted() => _interaction?.Interacted();
}
