using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject cubes;
    [SerializeField] private float cubeSpacing = 1f;
    [SerializeField] private int cubeDestroyCount = 0;
    [SerializeField] private int initialCubeCount;
    [SerializeField] private KeyCode cubeDestroyKey = KeyCode.Space;

    private List<GameObject> generatedCubes = new List<GameObject>();


    private void Start()
    {
        GenerateCubes(initialCubeCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(cubeDestroyKey))
        {
            DestroyCubes();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.layer == LayerMask.NameToLayer("CollectableCube"))
        {
            GenerateCubes(1);

            Destroy(otherObject.transform.parent.gameObject); //objenin ba�l� oldu�u parent objesine ula��p siliyor. B�ylelikle parent gidince child da gidiyor. 
        }
    }

    private void GenerateCubes(int cubeCount)
    {
        for (int i = 0; i < cubeCount; i++)
        {
            //GameObject cube = Instantiate(cubePrefab, transform.localPosition + Vector3.up * i * cubeSpacing, Quaternion.identity);
            GameObject cube = Instantiate(cubePrefab, cubes.transform);
            cube.transform.localPosition = Vector3.zero;

            generatedCubes.Add(cube);
        }

        SetCollectedCubesPositions();

        int generatedCubeCount = generatedCubes.Count;
        PlayerController.Instance.SetStickManPosition(generatedCubeCount);
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
        if (generatedCubes.Count == 0) return;

        for (int i = 0; i < cubeDestroyCount; i++)
        {
            int lastIndex = generatedCubes.Count - 1; //Listenin son eleman�n�n indeksini al�r.
            GameObject cube = generatedCubes[lastIndex]; //Listenin son indeksini temsil eden nesneyi al.
            generatedCubes.RemoveAt(lastIndex); //Listeden son eleman� yok eder.
            Destroy(cube); //Listeden ��kard���m�z son k�p� yok eder. (Kullanmad���mda son iki k�p oyunda kal�yor.)
        }


        SetCollectedCubesPositions();

        int generatedCubeCount = generatedCubes.Count;
        PlayerController.Instance.SetStickManPosition(generatedCubeCount);
    }
}
