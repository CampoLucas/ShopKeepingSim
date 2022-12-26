using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _body;
    
    [SerializeField] private float _speed = 5;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dir)
    {
        transform.position += new Vector3(dir.x, dir.y) * (_speed * Time.deltaTime);
    }
}
