using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject cubes;
    [SerializeField] private float cubeSpacing = 1f;
    [SerializeField] private int cubeCount = 0;
    [SerializeField] private int cubeDestroyCount = 0;
    [SerializeField] private KeyCode cubeDestroyKey = KeyCode.Space;

    private List<GameObject> generatedCubes = new List<GameObject>();


    private void Start()
    {
        GenerateCubes();
        PlayerController.Instance.SetStickManPosition(cubeCount);
    }

    private void Update()
    {
        //GenerateCubes();
        DestroyCubes();
        PlayerController.Instance.SetStickManPosition(generatedCubes.Count);
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectCube") && !generatedCubes.Contains(other.gameObject))
        {
            generatedCubes.Add(other.gameObject);
            other.gameObject.transform.SetParent(cubes.transform);
            cubeCount++;

            Destroy(other.gameObject);
        }
        SetCollectedCubesPositions();
    }
*/
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
                    int lastIndex = generatedCubes.Count - 1; //Listenin son eleman�n�n indeksini al�r.
                    GameObject cube = generatedCubes[lastIndex]; //Listenin son indeksini temsil eden nesneyi al.
                    generatedCubes.RemoveAt(lastIndex); //Listeden son eleman� yok eder.
                    Destroy(cube); //Listeden ��kard���m�z son k�p� yok eder. (Kullanmad���mda son iki k�p oyunda kal�yor.)
                }
            }
        }

        SetCollectedCubesPositions();
    }
}
