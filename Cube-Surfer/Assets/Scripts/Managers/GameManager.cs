using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStarted;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        isGameStarted = true;

        UIManager.Instance.SetState(UIState.Start);

        PlayerMovement.Instance.StartMove();
    }

    
}

