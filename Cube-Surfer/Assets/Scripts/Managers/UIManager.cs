using UnityEngine;

//Enum (numaraland�rma) D�rt farkl� durumu temsil eder
public enum UIState
{
    Idle,
    Start,
    Won,
    Fail
}

public class UIManager : MonoBehaviour
{
    //Singleton (tek �rnek) referans�
    public static UIManager Instance;

    //UI panellerine referanslar
    public GameObject startPanel;
    public GameObject swervePanel;

    //Ge�erli UI durumu
    private UIState currentState;

    //Betik �rne�i y�klenirken �a�r�l�r - ya�am d�ng�s� metodlar�ndan biri
    private void Awake()
    {
        //Instance'� ge�erli UIManager �rne�ine ayarlar, bu da bir singleton olu�turur
        Instance = this;
    }

    //ya�am d�ng�s� metodlar�ndan biri - ilk �er�eve g�ncellemesinden �nce �a�r�l�r
    private void Start()
    {
        //UI durumunu Idle (bo�ta) olarak ba�lat�r.
        SetState(UIState.Idle);
    }

    //'SetState' metodu, oyun durumuna ba�l� olarak UI'yi g�ncellemekten sorumludur.
    //Ge�erli UI durumunu ayarlar ve UI ��elerini mevcut duruma g�re g�nceller. 
    //Switch ifadesi ile duruma ba�l� olarak startPanel ve swervePanel'� etkinle�tirir veya devre d��� b�rak�r.
    public void SetState(UIState state)
    {
        currentState = state;

        switch (state)
        {
            case UIState.Idle:
                StartPanelEnabled(true);

                SwervePanelEnabled(false);
                break;
            case UIState.Start:
                StartPanelEnabled(false);

                SwervePanelEnabled(true);
                break;
            case UIState.Won:
                break;
            case UIState.Fail:
                break;
        }
    }

    //startPanel'i belirtilen 'status' durumuna g�re etkinle�tirir veya devre d��� b�rak�r.
    public void StartPanelEnabled(bool status)
    {
        //Mevcut durumun istenen durumla e�le�ip e�le�medi�ini kontrol ederek gereksiz de�i�iklikleri �nler.
        if (startPanel.activeSelf == status) return;

        startPanel.SetActive(status);
    }

    //'swervePanel''i belirtilen 'status' durumuna g�re etkinle�tirir veya devre d��� b�rak�r. 
    public void SwervePanelEnabled(bool status)
    {
        //Mevcut durumun istenen durumla e�le�ip e�le�medi�ini kontrol ederek gereksiz de�i�iklikleri �nler. 
        if (swervePanel.activeSelf == status) return;

        swervePanel.SetActive(status);
    }
}
