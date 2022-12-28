using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;

    public void Interactt()
    {
        if (!InteractionDetection(out var hit)) return;
        hit.collider.gameObject.GetComponent<IInteractable>()?.OnInteract();
    }

    private bool InteractionDetection(out RaycastHit2D hit)
    {
        hit = Physics2D.CircleCast(transform.position, 1f, Vector2.up, 1, interactableLayer);
        return hit;
    }
}
