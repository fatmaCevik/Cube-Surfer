using UnityEngine;

public class CollactableCube : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    public bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.layer == LayerMask.NameToLayer("ObstacleCube"))
        {
            CubeGenerator.Instance.LeaveCubesOnObstacle();
            otherObject.GetComponent<Collider>().enabled = false;
        }
    }
}