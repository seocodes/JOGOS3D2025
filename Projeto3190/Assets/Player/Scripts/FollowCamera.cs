using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 5.0f;
    public float rotationSpeed = 5.0f;
    public float smoothSpeed = 0.125f;

    private float currentRotation = 0f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        currentRotation += horizontalInput * rotationSpeed;

        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}