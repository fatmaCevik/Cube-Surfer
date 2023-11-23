using UnityEngine;

//Enum (numaralandýrma) Dört farklý durumu temsil eder
public enum UIState
{
    Idle,
    Start,
    Won,
    Fail
}

public class UIManager : MonoBehaviour
{
    //Singleton (tek örnek) referansý
    public static UIManager Instance;

    //UI panellerine referanslar
    public GameObject startPanel;
    public GameObject swervePanel;

    //Geçerli UI durumu
    private UIState currentState;

    //Betik örneði yüklenirken çaðrýlýr - yaþam döngüsü metodlarýndan biri
    private void Awake()
    {
        //Instance'ý geçerli UIManager örneðine ayarlar, bu da bir singleton oluþturur
        Instance = this;
    }

    //yaþam döngüsü metodlarýndan biri - ilk çerçeve güncellemesinden önce çaðrýlýr
    private void Start()
    {
        //UI durumunu Idle (boþta) olarak baþlatýr.
        SetState(UIState.Idle);
    }

    //'SetState' metodu, oyun durumuna baðlý olarak UI'yi güncellemekten sorumludur.
    //Geçerli UI durumunu ayarlar ve UI öðelerini mevcut duruma göre günceller. 
    //Switch ifadesi ile duruma baðlý olarak startPanel ve swervePanel'ý etkinleþtirir veya devre dýþý býrakýr.
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

    //startPanel'i belirtilen 'status' durumuna göre etkinleþtirir veya devre dýþý býrakýr.
    public void StartPanelEnabled(bool status)
    {
        //Mevcut durumun istenen durumla eþleþip eþleþmediðini kontrol ederek gereksiz deðiþiklikleri önler.
        if (startPanel.activeSelf == status) return;

        startPanel.SetActive(status);
    }

    //'swervePanel''i belirtilen 'status' durumuna göre etkinleþtirir veya devre dýþý býrakýr. 
    public void SwervePanelEnabled(bool status)
    {
        //Mevcut durumun istenen durumla eþleþip eþleþmediðini kontrol ederek gereksiz deðiþiklikleri önler. 
        if (swervePanel.activeSelf == status) return;

        swervePanel.SetActive(status);
    }
}
