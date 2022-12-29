using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The common variables and methods with the player and customer
/// </summary>
/// <typeparam name="T"></typeparam>
public class Character : Entity<PlayerSO>
{
    protected IMovement Movement;
    protected PlayerAnimation Animation;

    protected virtual void Awake()
    {
        Movement = GetComponent<IMovement>();
        Animation = GetComponent<PlayerAnimation>();
    }

    protected void Move(Vector2 dir) => Movement?.Move(dir);
}
