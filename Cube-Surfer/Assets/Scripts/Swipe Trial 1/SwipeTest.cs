using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    [SerializeField] private Swipe swipeControls;
    [SerializeField] private Transform player;
    [SerializeField] private float cubeMaxDistanceDelta;

    private Vector3 desiredPosition;

    private void Update()
    {
        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;
        if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, cubeMaxDistanceDelta * Time.deltaTime);
    }
}

