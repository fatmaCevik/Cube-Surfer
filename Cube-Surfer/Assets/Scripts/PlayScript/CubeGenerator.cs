using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject cubes;
    [SerializeField] private float cubeSpacing = 1f;
    [SerializeField] private int cubeCount = 5;
    [SerializeField] private int cubeDestroyCount = 0;
    [SerializeField] private KeyCode cubeDestroyKey = KeyCode.Space;

    private List<GameObject> generatedCubes = new List<GameObject>();


    private void Start()
    {
        GenerateCubes();
        PlayerController.Instance.SetStickManPosition(cubeCount);
    }

    void Update()
    {
        DestroyCubes();
        PlayerController.Instance.SetStickManPosition(cubeCount);
    }

    private void GenerateCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            //GameObject cube = Instantiate(cubePrefab, transform.localPosition + Vector3.up * i * cubeSpacing, Quaternion.identity);
            GameObject cube = Instantiate(cubePrefab, cubes.transform);
            cube.transform.localPosition = Vector3.zero;

            generatedCubes.Add(cube);

            //cube.transform.SetParent(cubes.transform); //Sefa'ya sor!!
        }

        SetCollectedCubesPositions();
    }

    private void SetCollectedCubesPositions()
    {
        int generatedCubeCount = generatedCubes.Count;

        for (int i = 0; i < generatedCubeCount; i++)
        {
            Transform cubeTr = generatedCubes[i].transform;
            cubeTr.localPosition = Vector3.up * cubeSpacing * (generatedCubeCount - (i + 1));
        }
    }

    private void DestroyCubes()
    {
        if (Input.GetKeyDown(cubeDestroyKey))
        {
            for (int i = 0; i < cubeDestroyCount; i++)
            {
                if (generatedCubes.Count > 0)
                {
                    int lastIndex = generatedCubes.Count - 1;
                    GameObject cube = generatedCubes[lastIndex];
                    generatedCubes.RemoveAt(lastIndex);
                    Destroy(cube);
                    cubeCount -= cubeDestroyCount;
                }
            }
        }

        SetCollectedCubesPositions();
    }
}
