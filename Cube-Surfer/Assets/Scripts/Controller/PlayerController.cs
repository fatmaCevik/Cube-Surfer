using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private GameObject stickMan;

    private void Awake()
    {
        instance = this;
    }

    public void SetStickManPositon(int cubeCount)
    {
        stickMan.transform.localPosition = Vector3.up * cubeCount;
    }

}
