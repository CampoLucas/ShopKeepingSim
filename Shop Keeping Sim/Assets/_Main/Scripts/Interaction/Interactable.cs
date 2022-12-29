using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Interactable : MonoBehaviour, IInteractable
{
    [field: SerializeField] public ItemSO Data { get; private set; }
    public bool CanInteract { get; protected set; }

    private void Awake()
    {
        CanInteract = true;
    }

    public virtual void Interacted()
    {
        
        
    }

    
}
