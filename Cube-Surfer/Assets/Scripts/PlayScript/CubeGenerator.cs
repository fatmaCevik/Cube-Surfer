using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    //[SerializeField] private Transform ground; 
    [SerializeField] private float cubeSpacing = 1f;
    [SerializeField] private int cubeCount = 5;
    [SerializeField] private float startingHeight = 1f;

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
            GameObject cube = Instantiate(cubePrefab, transform.position + Vector3.up * i * cubeSpacing, Quaternion.identity);

            generatedCubes.Add(cube);

            //cube.transform.position = new Vector3(cube.transform.position.x, startingHeight, cube.transform.position.z);

            cube.transform.SetParent(transform, true); //Sefa'ya sor!!
        }
    }



}
