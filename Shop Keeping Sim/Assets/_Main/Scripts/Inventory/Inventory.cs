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

    public void GetItem(IStorable storableItem)
    {
        var data = storableItem.Data;
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
        //UIManager.Instance.SetItemButton(newStockItem.Item, newStockItem.Stock);
    }

    public bool HasItem(IStorable itemToCheck) => _itemDictionary.ContainsKey(itemToCheck.Data.ID);
    public bool HasItem(string id) => _itemDictionary.ContainsKey(id);

    public int GetItemStock(IStorable item) =>
        _itemDictionary.TryGetValue(item.Data.ID, out var stock) ? stock.Stock : 0;

    public bool HasItems(List<IStorable> itemsToCheck)
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
