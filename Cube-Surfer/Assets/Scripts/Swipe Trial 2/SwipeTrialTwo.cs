using UnityEngine;

public class SwipeTrialTwo : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    
    private float dragDistance = Screen.height * 15 / 100;
    private float swipeTime;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Update()
    {
        /* if içerisindeki kod ekrana dokunan parmak sayýsý sýfýrdan büyükse ve 
          ilk parmaðýn dokunma aþamasý baþladýysa, yani ekrana yeni dokunduysa anlamýna gelir.
          Bu þekilde ekrana dokunulduðunda bir olay tetikleriz.
         */
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            swipeTime = Time.time;
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (Time.time - swipeTime < 0.5f)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if (endTouchPosition.x - startTouchPosition.x < -dragDistance)
                    Right();

                if (endTouchPosition.x - startTouchPosition.x > dragDistance)
                    Left();
            }
        }
    }
    private void Left()
    {
        cube.transform.position = new Vector3(cube.transform.position.x + 1, cube.transform.position.y, cube.transform.position.z); 
    }

    private void Right()
    {
        cube.transform.position = new Vector3(cube.transform.position.x - 1, cube.transform.position.y, cube.transform.position.z);
    }
}
