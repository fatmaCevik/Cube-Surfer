using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform targetZAxis;
    [SerializeField] private Transform targetYAxis;
    [SerializeField] private float smoothSpeed = 0.125f;
    //[SerializeField] private Vector3 offset;
    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - targetZAxis.position;
    }


    private void Update()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        if (targetZAxis == null) return;

        Vector3 targetPosition = Vector3.zero;
        targetPosition.y = targetYAxis.position.y;
        targetPosition.z = targetZAxis.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPosition + offset, smoothSpeed * Time.deltaTime);

    }
}
