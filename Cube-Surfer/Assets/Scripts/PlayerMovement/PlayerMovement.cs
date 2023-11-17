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

    private Vector2 touchStartPosition; //Dokunmatik hareketin baþlangýç poziyonunu saklamak için kullanýlýr.
    private Vector2 touchEndPosition; //Dokunmatik hareketin bitiþ pozisyonunu saklamak için kullanýlýr.
    private Vector2 swipeDelta; //Hareketin baþlangýç ve bitiþ pozisyonlarý aarasýndaki farký saklamak için kullanýlýr. 
    private bool isSpiweActive; // Hareketin devam edip etmediðini kontrol etmek için kullanýlýr. 
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
                    madeContact = true;
                    break;

                //Dokunma sürüklendikçe
                case TouchPhase.Moved:
                    //Dokunma baþlangýç ve bitiþ pozisyonlarý arasýndaki farký hesaplar
                    touchEndPosition = touch.position;
                    swipeDelta = touchEndPosition - touchStartPosition;

                    //Objeyi saða veya sola doðru hareket ettirir
                    playerModel.transform.localPosition += Vector3.right * swipeDelta.x * Time.deltaTime * swipeSpeed;

                    Vector3 playerClampedPosition = playerModel.transform.localPosition;
                    playerClampedPosition.x = Mathf.Clamp(playerClampedPosition.x, minClampPoint.localPosition.x, maxClampPoint.localPosition.x);
                    playerModel.transform.localPosition = playerClampedPosition;
                    //'swipeDelta.x' deðeri, dokunma hareketinin x ekseni üzerindeki deðiþikliði temsil eder.
                    // 'Time.deltaTime' ve 'swipeSpeed' ise, zaman baðýmlý olarak hareketin yumuþaklýðýný ve hýzýný kontrol eder. 

                    //Dokunma baþlangýç pozisyonunu güncelle
                    touchStartPosition = touch.position;
                    madeContact = true;
                    break;
                //Dokunma bittiðinde
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
