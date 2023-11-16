using UnityEngine;

public class SwipeTrialThree : MonoBehaviour
{
    //SwipeControl
    [SerializeField] private float swipeThreshold = 50f;
    [SerializeField] private GameObject cube;
    [SerializeField] private float swipeSpeed = 5f; //Ayarlanabilir hýz deðeri

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private bool isSwipeActive;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        //Dokunma algýlandýðýnda 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Dokunmanýn baþlangýç pozisyonunu kaydet
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                isSwipeActive = true;
            }

            //Dokunma sürükleniyorsa
            if (isSwipeActive && touch.phase == TouchPhase.Moved)
            {
                //Saða veya sola doðru yeterince sürüklendiyse
                //float swipeDeltaX = touch.position.x - touchStartPosition.x;

                touchEndPosition = touch.position;
                Vector2 swipeDelta = touchEndPosition - touchStartPosition;

                if (Mathf.Abs(swipeDelta.x) > swipeThreshold)
                {
                    //Hedef pozisyonu belirler
                    targetPosition = new Vector3(transform.position.x + Mathf.Sign(swipeDelta.x), transform.position.y, transform.position.z);

                    //Swipe yönlendirmesine göre iþlemleri yap!
                    if (swipeDelta.x > 0)
                    {
                        Right();
                    }
                    else
                    {
                        Left();
                    }

                    //Swipe iþlemleri tamamlandýðýnda
                    isSwipeActive = false;
                }
            }
    
            if (touch.phase == TouchPhase.Ended )
            {
                isSwipeActive = false; 
            }
            
        }

        //Yumuþak geçiþ yapmak için Lerp  kullan
        transform.position = Vector3.Lerp(transform.position, targetPosition, swipeSpeed * Time.deltaTime);
    }

    private void Right()
    {
        cube.transform.position = targetPosition = new Vector3(targetPosition.x + 1, targetPosition.y, targetPosition.z);
    }

    private void Left()
    {
        cube.transform.position = targetPosition = new Vector3(targetPosition.x - 1, targetPosition.y, targetPosition.z);
    }

}
