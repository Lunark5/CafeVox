using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Highlightable))]
public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _textObject;

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

    public void OnInteractPress()
    {
        OnInteractPressed?.Invoke();
    }

    public void OnInteractExit()
    {
        _highlighter.ResetHighlight();
        SetTextActive(false);
    }

    private void SetTextActive(bool active)
    {
        _textObject?.SetActive(active);
    }
}