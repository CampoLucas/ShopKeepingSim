using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector2 _dir;
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private float radius = 0.2f;
    [SerializeField] private float _speed = 5;
    [SerializeField] private LayerMask _collisionLayer;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dir)
    {
        _dir = dir;
        if (DetectObstacle(_dir, distance, radius)) return;
        transform.position += new Vector3(dir.x, dir.y) * (_speed * Time.deltaTime);
    }

    private bool DetectObstacle(Vector2 direction, float distance, float radius)
    {
        return Physics2D.CircleCast(transform.position, radius, direction, distance, _collisionLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(_dir.x, _dir.y) * distance, radius);
    }
}
