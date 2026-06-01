using UnityEngine.Events;

public class GlobalEvents
{
    private static GlobalEvents _instance;

    public static GlobalEvents Instance => _instance ??= new GlobalEvents();

    public UnityEvent<InventoryItem> OnItemPickedUp;

    public void SendItemPickedUp(InventoryItem inventoryItem)
    {
        OnItemPickedUp?.Invoke(inventoryItem);
    }
}