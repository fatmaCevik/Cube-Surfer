using UnityEngine;
using PathCreation;
using System.Runtime.CompilerServices;

public class MovementController : MonoBehaviour
{
    public static MovementController Instance;

    //Oyuncu hareket hýzý
    [SerializeField] private float movementSpeed;
    [SerializeField] private PathCreator pathCreator;

    private float distanceTravelled;

    //Oyuncunun hareketine izin verip vermediðini belirten bir boolean deðiþken
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
        //'isMoveEnabled' kontrol edilir, eðer false ise hareket etmez.
        if (!isMoveEnabled) return;

        distanceTravelled += movementSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void MovementEnabled(bool status)
    {
        //'isMoveEnabled' belirtilen duruma ('status') göre güncellenir. Eðer zaten belirtilen durumdaysa iþlem yapýlmaz.
        if (isMoveEnabled == status) return;

        isMoveEnabled = status;
    }

    
    public void StartMove()
    {
        //Oyuncu hareketine izin vermek için 'MovementEnabled' metodunu çaðýrýr.
        MovementEnabled(true);

        //'UIManager''daki 'SetState' metodunu kullanarak UI durumunu start olarak ayarlar. 
        //Bu oyunun baþlamýþ olduðunu belirten bir UI durumudur. 
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

    //private Vector2 touchStartPosition; //Dokunmatik hareketin baþlangýç poziyonunu saklamak için kullanýlýr.
    //private Vector2 touchEndPosition; //Dokunmatik hareketin bitiþ pozisyonunu saklamak için kullanýlýr.
    //private Vector2 swipeDelta; //Hareketin baþlangýç ve bitiþ pozisyonlarý aarasýndaki farký saklamak için kullanýlýr. 
    //private bool isSpiweActive; // Hareketin devam edip etmediðini kontrol etmek için kullanýlýr. 
    //private bool madeContact = false; 
    // Start is called before the first frame update
    /*private void MoveHorizontaly()
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
    }*/
