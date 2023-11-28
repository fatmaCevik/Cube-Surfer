using UnityEngine;
using UnityEngine.EventSystems;

public class SwerveController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField] private Transform swerveParent; // Oyuncu modelinin transform bile�eni.
	[SerializeField] private Transform minClampTr; 
	[SerializeField] private Transform maxClampTr;

	[SerializeField] float moveSensitivity; //Hareket hassasiyetini kontrol eden bir hassasiyet de�eri. 

	private Vector2 moveLastPos; //Son konumunu depolayan bir vekt�r.
	private PointerEventData mousePosHolder; //Fare pozisyonunu tutan bir PointerEventData nesnesi.

	//IDragHandler aray�z�nden gelen y�ntem, fare s�r�kleme olay�n� i�ler.
	public void OnDrag(PointerEventData eventData)
	{
		mousePosHolder = eventData;
		//'TouchDetectionMovement' metodunu �a��rarak fare hareketini i�ler.
		TouchDetectionMovement(mousePosHolder);
		//CLAMP ile k�s�tlamay� uygular.
		Clamp();
	}

	//Fare s�r�kleme hareketini i�leyen �zel bir metot.
	private void TouchDetectionMovement(PointerEventData eventData)
	{
		//'moveLastPos''i kontrol ederek fark vekt�r�n� hesaplar ve oyuncu modelini g�nceller.
		if (moveLastPos == Vector2.zero) moveLastPos = eventData.position;

		Vector2 difVec = eventData.position - moveLastPos;

		//MOVEMENT
		if (swerveParent != null)
		{
			swerveParent.localPosition += Vector3.right * difVec.x * moveSensitivity;

			moveLastPos = eventData.position;
		}
	}

	//IPointerUpHandler aray�z�nden gelen y�ntem, fare t�klama b�rakma olay�n� i�ler.
	public void OnPointerUp(PointerEventData eventData)
	{
		moveLastPos = Vector2.zero;

		if (mousePosHolder != null)
		{
			mousePosHolder.position = Vector2.zero;
		}
	}
	//IPointerDownHandler aray�z�ne gelen y�ntem, fare t�klama olay�n� i�ler.
	public void OnPointerDown(PointerEventData eventData)
	{
		//'mousePosHolder''a fare pozisyonunu atar.
		mousePosHolder = eventData;
	}

	//Player'�n pozisyonunu belirli s�n�rlar i�inde k�s�tlayan bir metot.
	public void Clamp()
	{
		if (swerveParent != null)
		{
			Vector3 clampedPos = swerveParent.localPosition;
			clampedPos.x = Mathf.Clamp(clampedPos.x, minClampTr.localPosition.x, maxClampTr.localPosition.x);
			swerveParent.localPosition = clampedPos;
		}
	}
}