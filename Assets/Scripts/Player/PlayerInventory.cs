using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryItem> _items;

    public InventoryItem SelectedItem { get; protected set; }

    public UnityEvent OnInventoryRefreshed;

    private void Awake()
    {
        _items = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        if (item == InventoryItem.CurrentItem) return;

        _items.Add(item);

        SelectedItem = item;

        OnInventoryRefreshed?.Invoke();
    }

    public void RemoveItem(InventoryItem item)
    {
        if (item == InventoryItem.CurrentItem) return;

        _items.Remove(item);

        SelectedItem = InventoryItem.None;

        OnInventoryRefreshed?.Invoke();
    }

    public bool HasItem(InventoryItem item)
    {
        return _items.Contains(item);
    }
}