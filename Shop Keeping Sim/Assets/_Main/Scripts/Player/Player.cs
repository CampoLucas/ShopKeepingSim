using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputs _inputs;

    private void Awake()
    {
        _inputs = GetComponent<PlayerInputs>();
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
        //Move method from the move script uses vector 2 parameter
        //Move method from animation script uses float parameter
    }

    private void Interact()
    {
        
    }
}
