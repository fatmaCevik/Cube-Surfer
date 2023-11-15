using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTrialTwo : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Update()
    {
        /* if i�erisindeki kod ekrana dokunan parmak say�s� s�f�rdan b�y�kse ve 
          ilk parma��n dokunma a�amas� ba�lad�ysa, yani ekrana yeni dokunduysa anlam�na gelir.
          Bu �ekilde ekrana dokunuldu�unda bir olay tetikleriz.
         */
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x < startTouchPosition.x)
                Right();

            if (endTouchPosition.x > startTouchPosition.x)
                Left();

        }
    }
    private void Left()
    {
        cube.transform.position = new Vector3(cube.transform.position.x + 1, cube.transform.position.y, cube.transform.position.z); 
    }

    private void Right()
    {
        cube.transform.position = new Vector3(cube.transform.position.x - 1, cube.transform.position.y, cube.transform.position.z);
    }
}
