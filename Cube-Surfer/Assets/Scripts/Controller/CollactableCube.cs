using UnityEditor.SceneManagement;
using UnityEngine;

public class CollactableCube : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;

    public bool isCollected;

    private Collider cubeCollider;
    private Rigidbody rb;

    private void Start()
    {
        cubeCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.layer == LayerMask.NameToLayer("ObstacleCube"))
        {
            CubeGenerator.Instance.LeaveCubesOnObstacle();
            otherObject.GetComponent<Collider>().enabled = false;
            cubeCollider.enabled = false;
            Destroy(rb);
            
        }
    }
}