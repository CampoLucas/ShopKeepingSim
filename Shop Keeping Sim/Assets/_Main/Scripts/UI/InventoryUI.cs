using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : BaseComponent
{
    [SerializeField] private ItemUI itemPrefab;
    [SerializeField] private Transform content;
    private Dictionary<string, ItemUI> _itemDictionary;

    private void Awake()
    {
        _itemDictionary ??= new Dictionary<string, ItemUI>();
    }

    public void AddItem(ItemSO data, int stock)
    {
        // if (_itemDictionary.TryGetValue(data.ID, out var item))
        // {
        //     item.Init(data, stock);
        //     _itemDictionary[data.ID] = item;
        // }
        // else
        // {
        //     item = Instantiate(itemPrefab, content);
        //     item.Init(data, stock);
        //     _itemDictionary[data.ID] = item;
        // }
        
        _itemDictionary ??= new Dictionary<string, ItemUI>();
        if (!_itemDictionary.TryGetValue(data.ID, out var item))
        {
            item = Instantiate(itemPrefab, content);
        }
        if (item == null) return;
        item.Init(data, stock);
        _itemDictionary[data.ID] = item;
    }

    public void Toggle() => gameObject.SetActive(!gameObject.activeSelf);
}
