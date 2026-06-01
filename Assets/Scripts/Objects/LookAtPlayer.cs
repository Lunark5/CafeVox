using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private void LateUpdate()
    {
        if (!Camera.main) return;
        
        transform.LookAt(Camera.main.transform);
    }
}