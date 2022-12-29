using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string ID;
    [field: SerializeField] public string Name;
    [field: SerializeField] public Sprite Icon;
}
