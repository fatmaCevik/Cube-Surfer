using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetStickManPosition(int cubeCount)
    {
        transform.localPosition = Vector3.up * cubeCount;
    }

}
