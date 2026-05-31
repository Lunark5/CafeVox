using UnityEngine;

public class PlayerObserveCamera : MonoBehaviour
{
    [SerializeField] private float _mouseSense;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _orientation;

    private const float SenseMultiplier = 200f;
    private const float FovMultiplier = 100f;
    private const float RotationMultiplier = 0.01f;

    private float _mouseX;
    private float _mouseY;
    private float _rotationX;
    private float _rotationY;

    private void Awake()
    {
        _mouseSense = GameManager.MouseSensitivity * SenseMultiplier;
        _camera.fieldOfView = 40 + GameManager.FOV * FovMultiplier;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.GamePaused = !GameManager.Instance.GamePaused;

            ControlPause();
        }

        if (GameManager.Instance.GamePaused) return;

        GetInput();
        Rotate(_rotationX, _rotationY, 0);
    }

    private void Rotate(float x, float y, float z)
    {
        _camera.transform.localRotation = Quaternion.Euler(x, y, z);
        _orientation.rotation = Quaternion.Euler(0, y, 0);
    }

    private void GetInput()
    {
        _mouseX = Input.GetAxisRaw("Mouse X");
        _mouseY = Input.GetAxisRaw("Mouse Y");

        _rotationY += _mouseX * _mouseSense * RotationMultiplier;
        _rotationX -= _mouseY * _mouseSense * RotationMultiplier;

        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
    }

    private void ControlPause()
    {
        if (GameManager.Instance.GamePaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}