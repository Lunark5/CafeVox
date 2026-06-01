using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryItem> _items;

    private void Awake()
    {
        _items = new();

        GlobalEvents.Instance.OnItemPickedUp.AddListener(AddItem);
    }

    public void AddItem(InventoryItem item)
    {
        print("picked up item - " + item);
        
        _items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        _items.Remove(item);
    }

    public bool HasItem(InventoryItem item)
    {
        return _items.Contains(item);
    }
}