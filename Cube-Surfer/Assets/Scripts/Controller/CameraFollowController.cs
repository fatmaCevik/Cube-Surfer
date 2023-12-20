using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 5f;

    //[SerializeField] private Transform targetZAxis;
    //[SerializeField] private Transform targetYAxis;
    [SerializeField] private float smoothSpeed = 0.125f;
    //[SerializeField] private Vector3 offset;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
        //offset = transform.position - targetZAxis.position;
    }


    private void Update()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        if (target == null) return;
        //if (targetZAxis == null) return;
        Vector3 targetPosition = target.position + offset;


        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        //targetPosition.y = targetYAxis.position.y;
        //targetPosition.z = targetZAxis.position.z;

        //transform.position = Vector3.Lerp(transform.position, targetPosition + offset, smoothSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        
        transform.LookAt(target);
    }
    
}
