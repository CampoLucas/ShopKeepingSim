using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfits : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Texture defaultOutfit;
    private static readonly int MainTex = Shader.PropertyToID("_Main_Tex");

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeOutfit();
    }

    public void ChangeOutfit(Texture outfit)
    {
        _sprite.material.SetTexture(MainTex, outfit);
    }
    public void ChangeOutfit() => ChangeOutfit(defaultOutfit);
}
