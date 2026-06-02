using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInteractableCamera : MonoBehaviour
{
    [SerializeField] private float _interactRange = 5f;
    [SerializeField] private float _interactRestTime = 1f;
    [SerializeField] private LayerMask _interactLayer;

    [SerializeField] private PlayerInventory _playerInventory;

    private Camera _camera;
    private IInteractable _lastInteractObject;

    private bool _canUse = true;

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
        var ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (!Physics.Raycast(ray, out var hit, _interactRange, _interactLayer)
            || !hit.collider.TryGetComponent<IInteractable>(out var interactableObject))
        {
            ResetInteractObject();

            return;
        }

        if (_lastInteractObject != interactableObject) ResetInteractObject();

        if (_lastInteractObject == interactableObject) return;

        interactableObject.OnInteractEnter();

        _lastInteractObject = interactableObject;
    }

    private void CheckButtons()
    {
        if (!_canUse) return;
        if (!Input.GetButton($"Use")) return;

        _lastInteractObject?.OnInteractPress(_playerInventory);

        StartCoroutine(ResetUse());
    }

    private void ResetInteractObject()
    {
        if (_lastInteractObject == null) return;

        _lastInteractObject.OnInteractExit();
        _lastInteractObject = null;
    }

    private IEnumerator ResetUse()
    {
        _canUse = false;

        yield return new WaitForSeconds(_interactRestTime);

        _canUse = true;
    }
}