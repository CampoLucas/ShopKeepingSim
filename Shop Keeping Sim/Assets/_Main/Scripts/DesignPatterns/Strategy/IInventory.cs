using System.Collections.Generic;

public interface IInventory
{
    /// <summary>
    /// Adds items to the inventory
    /// </summary>
    /// <param name="item"> The scriptable object of the item </param>
    /// <param name="amount"> The amount of items</param>
    void AddItem(ItemSO item, int amount);
    /// <summary>
    /// Removes items from the inventory
    /// </summary>
    /// <param name="item"> The scriptable object </param>
    /// <param name="amount"> The amount to remove </param>
    void RemoveItem(ItemSO item, int amount);
    /// <summary>
    /// Checks if it has an item
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    bool HasItem(ItemSO data);
    /// <summary>
    /// Checks if it has an item that has more than a certain amount of stock
    /// </summary>
    /// <param name="data"></param>
    /// <param name="amount"> stock </param>
    /// <returns></returns>
    bool HasItem(ItemSO data, int amount);
    /// <summary>
    /// Checks if it has an item from the id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool HasItem(string id);
    /// <summary>
    /// Returns the amount of stock from an item
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    int GetItemStock(ItemSO data);
}