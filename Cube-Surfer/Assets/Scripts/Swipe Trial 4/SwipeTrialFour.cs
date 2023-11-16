using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrialFour : MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 5f;

    private Vector2 touchStartPosition; //Dokunmatik hareketin ba�lang�� poziyonunu saklamak i�in kullan�l�r.
    private Vector2 touchEndPosition; //Dokunmatik hareketin biti� pozisyonunu saklamak i�in kullan�l�r.
    private Vector2 swipeDelta; //Hareketin ba�lang�� ve biti� pozisyonlar� aaras�ndaki fark� saklamak i�in kullan�l�r. 
    private bool isSpiweActive; // Hareketin devam edip etmedi�ini kontrol etmek i�in kullan�l�r. 

    void Update()
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
                    break;

                //Dokunma s�r�klendik�e
                case TouchPhase.Moved:
                    //Dokunma ba�lang�� ve biti� pozisyonlar� aras�ndaki fark� hesaplar
                    touchEndPosition = touch.position;
                    swipeDelta = touchEndPosition - touchStartPosition;

                    //Objeyi sa�a veya sola do�ru hareket ettirir
                    transform.Translate(new Vector3(swipeDelta.x, 0, 0) * Time.deltaTime * swipeSpeed);
                    //'swipeDelta.x' de�eri, dokunma hareketinin x ekseni �zerindeki de�i�ikli�i temsil eder.
                    // 'Time.deltaTime' ve 'swipeSpeed' ise, zaman ba��ml� olarak hareketin yumu�akl���n� ve h�z�n� kontrol eder. 

                    //Dokunma ba�lang�� pozisyonunu g�ncelle
                    touchStartPosition = touch.position;
                    break;
                //Dokunma bitti�inde
                case TouchPhase.Ended:
                    isSpiweActive = false;
                    break;
            }
        }
    }
}
