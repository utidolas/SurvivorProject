using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target; // target to follow

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
