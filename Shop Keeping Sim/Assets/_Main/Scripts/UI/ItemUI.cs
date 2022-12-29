using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private Image icon;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        
    }

    public void Init(ItemSO data, int stock)
    {
        if (!_text) Awake();
        
        SetItemText(ref _text, data.name, stock);
        icon.sprite = data.Icon;
    }

    private void SetItemText(ref TMP_Text text, in string itemName, in int stock)
    {
        text.text = $"<align=left>{itemName}<line-height=0><br><align=right>{stock:D2}<line-height=1em>";
    }
}
