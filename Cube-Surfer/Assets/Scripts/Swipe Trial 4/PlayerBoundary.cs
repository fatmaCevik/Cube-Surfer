using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;
    //[SerializeField] private float boundaryWidth = 3f;

    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float newPosition = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;

        //Yeni pozisyonu sýnýrla
        transform.position = new Vector3(Mathf.Clamp(newPosition, leftBoundary.position.x, rightBoundary.position.x), transform.position.y, transform.position.z);

        //Yeni pozisyonu sýnýrla
        //transform.position = new Vector3(Mathf.Clamp(newPosition, boundaryCenter.position.x - boundaryWidth / 2, boundaryCenter.position.x + boundaryWidth / 2), transform.position.y, transform.position.z);
    }
}
