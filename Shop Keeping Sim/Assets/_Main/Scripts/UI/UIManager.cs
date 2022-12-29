using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static readonly object Padlock = new object();
    private UIInput _input;
    [SerializeField] private InventoryUI _inventory;
    
    public static UIManager Inst = null;

    private UIManager()
    {
        
    }

    public static UIManager Instance { get { lock (Padlock) return Inst; } }

    private void Awake()
    {
        lock (Padlock)
        {
            if (Inst == null) Inst = this;
            else
            {
                Destroy(gameObject);
            }
        }
        
        _input = GetComponent<UIInput>();
        if (!_input) Debug.Log("No input");
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
        if (!_inventory) return;
        _inventory.AddItem(item, stock);
    }

    public void ToggleInventory()
    {
        if (!_inventory) return;
        else _inventory.Toggle();
    }
}
