using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The logic of how the player interacts with the world
/// </summary>
[RequireComponent(typeof(Player))]
public class Interaction : MonoBehaviour, IInteraction
{
    private PlayerSO _stats;

    private void Awake()
    {
        _stats = GetComponent<Player>().GetData();
    }

    /// <summary>
    /// Looks for the interface IInteractable and executes the method on interact
    /// </summary>
    public void Interact()
    {
        if (!InteractionDetection(out var hit)) return;
        hit.collider.gameObject.GetComponent<IInteractable>()?.Interacted();
    }

    private bool InteractionDetection(out RaycastHit2D hit)
    {
        hit = Physics2D.CircleCast(transform.position, _stats.InteractionRadius, Vector2.up, 1, _stats.InteractionMask);
        return hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (!_stats) return;
        Gizmos.DrawWireSphere(transform.position, _stats.InteractionRadius);
    }
}
