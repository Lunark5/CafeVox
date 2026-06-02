using TMPro;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private string CurrentItemText = "Текущий предмет: {0}";

    private void Awake()
    {
        _playerInventory.OnInventoryRefreshed.AddListener(UpdateInventoryText);

        UpdateInventoryText();
    }

    private void UpdateInventoryText()
    {
        _inventoryText.text = string.Format(CurrentItemText, _playerInventory.SelectedItem);
    }
}