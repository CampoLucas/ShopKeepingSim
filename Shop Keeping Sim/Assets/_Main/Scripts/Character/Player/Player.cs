using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputs _inputs;
    private Movement _move;
    private PlayerAnimation _anim;
    private Interact _interact;

    private void Awake()
    {
        _inputs = GetComponent<PlayerInputs>();
        _move = GetComponent<Movement>();
        _anim = GetComponent<PlayerAnimation>();
        _interact = GetComponent<Interact>();
    }

    private void Start()
    {
        if (!_inputs) return;
        _inputs.OnMovement += Move;
        _inputs.OnInteraction += Interact;
    }

    private void Update()
    {
        if (_anim & _inputs) _anim.MovementAnimation(_inputs.MoveDir);
    }

    private void Move(Vector2 dir)
    {
        if (_move) _move.Move(dir);
    }
    
    private void Interact()
    {
        if (_interact) _interact.Interactt();
    }

    private void EnableInputs(bool canUseInputs) => _inputs.EnableInputs(canUseInputs);

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
}
