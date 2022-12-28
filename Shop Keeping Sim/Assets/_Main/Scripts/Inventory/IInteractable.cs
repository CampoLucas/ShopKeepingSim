using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    ItemSO Data { get; }
    bool CanInteract { get; }
    void OnInteract();
}
