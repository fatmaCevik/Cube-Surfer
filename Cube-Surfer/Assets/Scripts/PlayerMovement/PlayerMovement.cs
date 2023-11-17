using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerModel;
    [SerializeField] private float swipeSpeed = 5f;
    [SerializeField] private Transform minClampPoint;
    [SerializeField] private Transform maxClampPoint;
    [SerializeField] private float movementSpeed;

    private Vector2 touchStartPosition; //Dokunmatik hareketin ba�lang�� poziyonunu saklamak i�in kullan�l�r.
    private Vector2 touchEndPosition; //Dokunmatik hareketin biti� pozisyonunu saklamak i�in kullan�l�r.
    private Vector2 swipeDelta; //Hareketin ba�lang�� ve biti� pozisyonlar� aaras�ndaki fark� saklamak i�in kullan�l�r. 
    private bool isSpiweActive; // Hareketin devam edip etmedi�ini kontrol etmek i�in kullan�l�r. 
    private bool madeContact = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontaly();
        MoveForward();
    }

    private void MoveHorizontaly()
    {
        //Dokunma alg�land���nda, dokunmatik bilgilerini almak i�in kullan�l�r
        if (Input.touchCount > 0)
        {
            //�lk dokunmatik giri�i al
            Touch touch = Input.GetTouch(0);

            //'switch', dokunmatik olay�n durumunu kontrol eder
            switch (touch.phase)
            {
                //Dokunma ba�lad���nda, ba�lang�� pozisyonunu kaydeder, Swipe hareketinin aktifli�ini true yapar.
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    isSpiweActive = true;
                    madeContact = true;
                    break;

                //Dokunma s�r�klendik�e
                case TouchPhase.Moved:
                    //Dokunma ba�lang�� ve biti� pozisyonlar� aras�ndaki fark� hesaplar
                    touchEndPosition = touch.position;
                    swipeDelta = touchEndPosition - touchStartPosition;

                    //Objeyi sa�a veya sola do�ru hareket ettirir
                    playerModel.transform.localPosition += Vector3.right * swipeDelta.x * Time.deltaTime * swipeSpeed;

                    Vector3 playerClampedPosition = playerModel.transform.localPosition;
                    playerClampedPosition.x = Mathf.Clamp(playerClampedPosition.x, minClampPoint.localPosition.x, maxClampPoint.localPosition.x);
                    playerModel.transform.localPosition = playerClampedPosition;
                    //'swipeDelta.x' de�eri, dokunma hareketinin x ekseni �zerindeki de�i�ikli�i temsil eder.
                    // 'Time.deltaTime' ve 'swipeSpeed' ise, zaman ba��ml� olarak hareketin yumu�akl���n� ve h�z�n� kontrol eder. 

                    //Dokunma ba�lang�� pozisyonunu g�ncelle
                    touchStartPosition = touch.position;
                    madeContact = true;
                    break;
                //Dokunma bitti�inde
                case TouchPhase.Ended:
                    isSpiweActive = false;
                    madeContact = true;
                    break;
            }


        }
    }

    private void MoveForward()
    {
        //if (isSpiweActive == true)
        //if(Input.touchCount > 0)
        if (madeContact == true)
        {
            playerModel.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }

    }
}
