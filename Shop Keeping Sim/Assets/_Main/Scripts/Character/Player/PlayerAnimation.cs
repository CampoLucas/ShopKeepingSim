using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void MovementAnimation(Vector2 dir)
    {
        _anim.SetFloat(Vertical, dir.y, .1f, Time.deltaTime);
        _anim.SetFloat(Horizontal, dir.x, .1f, Time.deltaTime);
    }

    public void IdleAnimation() => MovementAnimation(Vector2.zero);
}
