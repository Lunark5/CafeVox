using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _groundMultiplier = 10f;
    [SerializeField] private float _groundDrag = 5f;
    [SerializeField] private float _gravityScale = 5f;

    [SerializeField] private Transform _orientation;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.freezeRotation = true;
        _rigidbody.linearDamping = _groundDrag;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.GamePaused) return;

        ControlGravity();
        MovePlayer();
    }

    private void Update()
    {
        if (GameManager.Instance.GamePaused) return;

        GetInput();

        if (_rigidbody.linearVelocity.magnitude > _moveSpeed)
        {
            _rigidbody.linearVelocity = Vector3.ClampMagnitude(_rigidbody.linearVelocity, _moveSpeed);
        }
    }

    private void GetInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = _orientation.forward * vertical + _orientation.right * horizontal;
    }

    private void MovePlayer()
    {
        _rigidbody.AddForce(_moveDirection.normalized * (_moveSpeed * _groundMultiplier),
            ForceMode.Acceleration);
    }

    private void ControlGravity()
    {
        _rigidbody.AddForce(Physics.gravity * ((_gravityScale - 1) * _rigidbody.mass));
    }
}