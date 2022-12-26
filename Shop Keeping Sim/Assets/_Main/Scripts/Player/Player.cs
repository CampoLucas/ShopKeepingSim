using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputs _inputs;
    private Movement _move;
    private ObstacleDetection _detection;
    private PlayerAnimation _anim;

    private void Awake()
    {
        _inputs = GetComponent<PlayerInputs>();
        _move = GetComponent<Movement>();
        _detection = GetComponent<ObstacleDetection>();
        _anim = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        if (_inputs)
        {
            _inputs.OnMovement += Move;
            _inputs.OnInteraction += Interact;
        }
    }

    private void Update()
    {
        if (_anim) _anim.MovementAnimation(_inputs.MoveDir);
    }

    private void Move(Vector2 dir, float amount)
    {
        if (_detection && _detection.Detect(dir)) return;
        if (_move) _move.Move(dir);
    }
    

    private void Interact()
    {
        
    }
}
