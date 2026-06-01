using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Highlightable : MonoBehaviour
{
    [SerializeField] private Color _highlightedColor;

    private Renderer _renderer;
    private Color _originalColor;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    public void Highlight()
    {
        _renderer.material.color = _highlightedColor;
    }

    public void ResetHighlight()
    {
        _renderer.material.color = _originalColor;
    }
}