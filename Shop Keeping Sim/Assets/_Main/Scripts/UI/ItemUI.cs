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
    [field: SerializeField] public ItemSO Data { get; private set; }
    [field: SerializeField] public int Stock { get; private set; }

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        if (!Data) return;
        Init(Data, 1);
    }

    public void Init(ItemSO data, int stock)
    {
        Data = data;
        Stock = stock;
        _text.text = $"<align=left>{Data.Name}<line-height=0><br><align=right>{Stock:D2}<line-height=1em>";
        icon.sprite = Data.Icon;
    }
}
