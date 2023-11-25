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
    }

    void Update()
    {
        
    }

    private void GenerateCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            GameObject cube = Instantiate(cubePrefab, transform.localPosition + Vector3.up * i * cubeSpacing, Quaternion.identity);

            generatedCubes.Add(cube);

            cube.transform.SetParent(cubes.transform, false); //Sefa'ya sor!!
        }
    }



}
