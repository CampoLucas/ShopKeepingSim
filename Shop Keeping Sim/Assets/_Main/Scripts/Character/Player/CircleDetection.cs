using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetection : MonoBehaviour
{
    private Vector2 _dir;
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private float radius = 0.2f;

    [SerializeField] private LayerMask _collisionLayer;
    
    public bool Detect(Vector2 direction, out RaycastHit2D hit)
    {
        _dir = direction;
        hit = Physics2D.CircleCast(transform.position, radius, direction, distance, _collisionLayer);
        return hit;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(_dir.x, _dir.y) * distance, radius);
    }
}
