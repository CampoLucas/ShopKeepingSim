using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

public class Inventory : MonoBehaviour
{
    private Dictionary<string, InventoryItem> _itemDictionary;
    //private List<InventoryItem> _itemsStoredUp;
    public static Inventory Inst = null;
    private static readonly object Padlock = new object();

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

    public void GetItem(ItemSO data)
    {
        //var data = interactableItem.Data;
        if (_itemDictionary.TryGetValue(data.ID, out var stockItem))
        {
            stockItem.IncreaseStock();
            _itemDictionary[data.ID] = stockItem;
        }
        else
        {
            _itemDictionary.Add(data.ID, new InventoryItem(data));
        }
        
        //adds it to the ui
        var newStockItem = _itemDictionary[data.ID];
        UIManager.Instance.AddItem(newStockItem.Item, newStockItem.Stock);
    }

    public void AddItem(ItemSO item, int amount)
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

    public bool HasItem(ItemSO data) => _itemDictionary.ContainsKey(data.ID);
    public bool HasItem(string id) => _itemDictionary.ContainsKey(id);

    public int GetItemStock(ItemSO data) =>
        _itemDictionary.TryGetValue(data.ID, out var stock) ? stock.Stock : 0;

    public bool HasItems(List<IInteractable> itemsToCheck)
    {
        foreach (var itemToCheck in itemsToCheck)
        {
            if (!_itemDictionary.ContainsKey(itemToCheck.Data.ID))
            {
                return false;
            }
        }

        return true;
    }
    
    public ItemSO GetItemFromPool(string idToCheck)
    {
        if(!_itemDictionary.TryGetValue(idToCheck, out var stockItem)) return null;

        if(stockItem.DecreaseStock() > 0) return stockItem.Item;

        var itemToReturn = stockItem.Item;
        _itemDictionary.Remove(idToCheck);
        return itemToReturn;
    }
}
