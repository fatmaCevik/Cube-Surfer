using UnityEngine;
using PathCreation;
using System.Runtime.CompilerServices;

public class MovementController : MonoBehaviour
{
    public static MovementController Instance;

    //Oyuncu hareket h�z�
    [SerializeField] private float movementSpeed;
    [SerializeField] private PathCreator pathCreator;

    private float distanceTravelled;

    //Oyuncunun hareketine izin verip vermedi�ini belirten bir boolean de�i�ken
    private bool isMoveEnabled;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        MoveForward();
        //MoveHorizontaly();
    }

    private void MoveForward()
    {
        //'isMoveEnabled' kontrol edilir, e�er false ise hareket etmez.
        if (!isMoveEnabled) return;

        distanceTravelled += movementSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void MovementEnabled(bool status)
    {
        //'isMoveEnabled' belirtilen duruma ('status') g�re g�ncellenir. E�er zaten belirtilen durumdaysa i�lem yap�lmaz.
        if (isMoveEnabled == status) return;

        isMoveEnabled = status;
    }

    
    public void StartMove()
    {
        //Oyuncu hareketine izin vermek i�in 'MovementEnabled' metodunu �a��r�r.
        MovementEnabled(true);

        //'UIManager''daki 'SetState' metodunu kullanarak UI durumunu start olarak ayarlar. 
        //Bu oyunun ba�lam�� oldu�unu belirten bir UI durumudur. 
        //UIManager.Instance.SetState(UIState.Start);
    }
}




    //[SerializeField] private GameObject playerModel;
    //[SerializeField] private GameObject playerParent;
    //[SerializeField] private float swipeSpeed = 5f;
    //[SerializeField] private Transform minClampPoint;
    //[SerializeField] private Transform maxClampPoint;
    //[SerializeField] private CanvasGroup canvasGroup;
    //[SerializeField] private RectTransform panelRectTransform;

    //private Vector2 touchStartPosition; //Dokunmatik hareketin ba�lang�� poziyonunu saklamak i�in kullan�l�r.
    //private Vector2 touchEndPosition; //Dokunmatik hareketin biti� pozisyonunu saklamak i�in kullan�l�r.
    //private Vector2 swipeDelta; //Hareketin ba�lang�� ve biti� pozisyonlar� aaras�ndaki fark� saklamak i�in kullan�l�r. 
    //private bool isSpiweActive; // Hareketin devam edip etmedi�ini kontrol etmek i�in kullan�l�r. 
    //private bool madeContact = false; 
    // Start is called before the first frame update
    /*private void MoveHorizontaly()
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
    }*/
