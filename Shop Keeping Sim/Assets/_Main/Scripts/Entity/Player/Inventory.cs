using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A struct that is stored inside a dictionary in the inventory
/// </summary>
public struct InventoryItem
{
    public ItemSO Item { get; private set; }
    public int Stock { get; private set; }

    public InventoryItem(ItemSO item)
    {
        Item = item;
        Stock = 1;
    }
    
    public InventoryItem(ItemSO item, int stock)
    {
        Item = item;
        Stock = stock;
    }

    public int IncreaseStock() => Stock ++;
    public int IncreaseStock(int amount) => Stock += amount;
    public int DecreaseStock() => Stock --;
    public int DecreaseStock(int amount) => Stock -= amount;
}

/// <summary>
/// The inventory is a singleton that is called without needing the reference of the player
/// </summary>
public class Inventory : MonoBehaviour, IInventory
{
    private Dictionary<string, InventoryItem> _itemDictionary;
    private static readonly object Padlock = new object();
    public static Inventory Inst = null;

    private Inventory()
    {
        
    }

    public static Inventory Instance { get { lock (Padlock) return Inst; } }
    
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

        _itemDictionary = new Dictionary<string, InventoryItem>();
    }

    public void AddItem(ItemSO item, int amount = 1)
    {
        if (_itemDictionary.TryGetValue(item.ID, out var stockItem))
        {
            stockItem.IncreaseStock(amount);
            _itemDictionary[item.ID] = stockItem;
        }
        else
        {
            _itemDictionary.Add(item.ID, new InventoryItem(item, amount));
        }
        
        var newStockItem = _itemDictionary[item.ID];
        UIManager.Instance.AddItem(newStockItem.Item, newStockItem.Stock);
    }

    public void RemoveItem(ItemSO item, int amount = 1)
    {
        if (!_itemDictionary.TryGetValue(item.ID, out var stockItem)) return;
        stockItem.DecreaseStock(amount);
        _itemDictionary[item.ID] = stockItem;
    }

    public bool HasItem(ItemSO data) => _itemDictionary.ContainsKey(data.ID);
    public bool HasItem(ItemSO data, int amount) =>
        _itemDictionary.TryGetValue(data.ID, out var stockItem) && stockItem.Stock >= amount;
    public bool HasItem(string id) => _itemDictionary.ContainsKey(id);
    public int GetItemStock(ItemSO data) =>
        _itemDictionary.TryGetValue(data.ID, out var stock) ? stock.Stock : 0;
}
