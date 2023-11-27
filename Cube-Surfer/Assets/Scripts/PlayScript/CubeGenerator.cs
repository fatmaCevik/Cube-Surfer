using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject cubes;
    [SerializeField] private float cubeSpacing = 1f;
    [SerializeField] private int cubeCount = 5;

    private List<GameObject> generatedCubes = new List<GameObject>();

    void Start()
    {
        GenerateCubes();
        PlayerController.instance.SetStickManPositon(cubeCount);
    }

    void Update()
    {
        
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


}
