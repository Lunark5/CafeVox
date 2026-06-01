using UnityEngine;

public class GivePlayerItem : MonoBehaviour
{
    [SerializeField] private InventoryItem _inventoryItem;

    public void GiveItemToPlayer()
    {
        GlobalEvents.Instance.SendItemPickedUp(_inventoryItem);
    }
}