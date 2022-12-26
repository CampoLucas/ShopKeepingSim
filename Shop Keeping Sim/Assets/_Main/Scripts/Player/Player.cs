using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputs _inputs;
    private Movement _move;

    private void Awake()
    {
        _inputs = GetComponent<PlayerInputs>();
        _move = GetComponent<Movement>();
    }

    private void Start()
    {
        if (_inputs)
        {
            _inputs.OnMovement += Move;
            _inputs.OnInteraction += Interact;
        }
    }

    private void Move(Vector2 dir, float amount)
    {
        if (_move) _move.Move(dir);
        //Move method from animation script uses float parameter
    }

    private void Interact()
    {
        
    }
}
