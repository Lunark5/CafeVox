using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInteractableCamera : MonoBehaviour
{
    [SerializeField] private float _interactRange = 5f;
    [SerializeField] private LayerMask _interactLayer;

    private Camera _camera;
    private IInteractable _lastInteractObject;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        CheckInteract();
        CheckButtons();
    }

    private void CheckInteract()
    {
        if (!Physics.Raycast(_camera.ScreenPointToRay(GetCamerMidPoint()), out var hit, _interactRange, _interactLayer))
        {
            ResetInteractObject();

            return;
        }

        if (!hit.collider.TryGetComponent<IInteractable>(out var interactableObject)) return;

        if (_lastInteractObject != interactableObject) ResetInteractObject();

        if (_lastInteractObject == interactableObject) return;

        interactableObject.OnInteractEnter();

        _lastInteractObject = interactableObject;
    }

    private void CheckButtons()
    {
        if (!Input.GetButton($"Use")) return;
        
        _lastInteractObject?.OnInteractPress();
    }

    private void ResetInteractObject()
    {
        if (_lastInteractObject == null) return;
        
        _lastInteractObject.OnInteractExit();
        _lastInteractObject = null;
    }

    private Vector3 GetCamerMidPoint() => new(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0.1f);
}