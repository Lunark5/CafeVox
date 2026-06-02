using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Highlightable))]
public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _textObject;
    [SerializeField] private InventoryItem _inventoryItem;
    [SerializeField] private InventoryItem _requireItem;

    private Highlightable _highlighter;

    public UnityEvent OnInteractPressed;

    private void Awake()
    {
        _highlighter = GetComponent<Highlightable>();
        SetTextActive(false);
    }

    public void OnInteractEnter()
    {
        _highlighter.Highlight();
        SetTextActive(true);
    }

    public void OnInteractPress(PlayerInventory playerInventory)
    {
        if (_requireItem != InventoryItem.None
            && !playerInventory.HasItem(_requireItem))
        {
            return;
        }

        playerInventory.AddItem(_inventoryItem);

        OnInteractPressed?.Invoke();
    }

    public void OnInteractExit()
    {
        _highlighter.ResetHighlight();
        SetTextActive(false);
    }

    private void SetTextActive(bool active)
    {
        if (!_textObject) return;

        _textObject?.SetActive(active);
    }
}