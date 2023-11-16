using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrialFour : MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 5f;

    private Vector2 touchStartPosition; //Dokunmatik hareketin baþlangýç poziyonunu saklamak için kullanýlýr.
    private Vector2 touchEndPosition; //Dokunmatik hareketin bitiþ pozisyonunu saklamak için kullanýlýr.
    private Vector2 swipeDelta; //Hareketin baþlangýç ve bitiþ pozisyonlarý aarasýndaki farký saklamak için kullanýlýr. 
    private bool isSpiweActive; // Hareketin devam edip etmediðini kontrol etmek için kullanýlýr. 

    void Update()
    {   
        //Dokunma algýlandýðýnda, dokunmatik bilgilerini almak için kullanýlýr
        if (Input.touchCount > 0)
        {
            //Ýlk dokunmatik giriþi al
            Touch touch = Input.GetTouch(0);

            //'switch', dokunmatik olayýn durumunu kontrol eder
            switch (touch.phase)
            {
                //Dokunma baþladýðýnda, baþlangýç pozisyonunu kaydeder, Swipe hareketinin aktifliðini true yapar.
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    isSpiweActive = true;
                    break;

                //Dokunma sürüklendikçe
                case TouchPhase.Moved:
                    //Dokunma baþlangýç ve bitiþ pozisyonlarý arasýndaki farký hesaplar
                    touchEndPosition = touch.position;
                    swipeDelta = touchEndPosition - touchStartPosition;

                    //Objeyi saða veya sola doðru hareket ettirir
                    transform.Translate(new Vector3(swipeDelta.x, 0, 0) * Time.deltaTime * swipeSpeed);
                    //'swipeDelta.x' deðeri, dokunma hareketinin x ekseni üzerindeki deðiþikliði temsil eder.
                    // 'Time.deltaTime' ve 'swipeSpeed' ise, zaman baðýmlý olarak hareketin yumuþaklýðýný ve hýzýný kontrol eder. 

                    //Dokunma baþlangýç pozisyonunu güncelle
                    touchStartPosition = touch.position;
                    break;
                //Dokunma bittiðinde
                case TouchPhase.Ended:
                    isSpiweActive = false;
                    break;
            }
        }
    }
}
