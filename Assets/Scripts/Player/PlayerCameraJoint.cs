using UnityEngine;

public class PlayerCameraJoint : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;

    private void Update()
    {
        transform.position = _cameraPosition.position;
    }
}