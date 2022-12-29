using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pay : Interactable
{
    public override void Interacted()
    {
        base.Interacted();
        if (!CanInteract) return;
        AddMoney(Random.Range(15, 100));
        CanInteract = false;
    }
    
    private void AddMoney(int amount)
    {
        Inventory.Instance.AddItem(Data, amount);
    }
}
