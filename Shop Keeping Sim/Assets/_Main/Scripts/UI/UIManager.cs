using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIInput _input;
    private InventoryUI _inventory;
    [SerializeField] private InventoryUI inventoryPrefab;

    private void Awake()
    {
        _input = GetComponent<UIInput>();
        if (!_input) Debug.Log("No input");
        _inventory = GetComponentInChildren<InventoryUI>();
    }

    private void Start()
    {
        if (_input)
        {
            _input.OnInventoryInput += ToggleInventory;
        }
    }

    private void OnDisable()
    {
        if (_input)
        {
            _input.OnInventoryInput -= ToggleInventory;
        }
    }

    public void AddItem(ItemSO item, int stock)
    {
        if (!_inventory) _inventory = Instantiate(inventoryPrefab, transform);
        _inventory.AddItem(item, stock);
    }

    public void ToggleInventory()
    {
        if (!_inventory) _inventory = Instantiate(inventoryPrefab, transform);
        else _inventory.Toggle();
    }
}
