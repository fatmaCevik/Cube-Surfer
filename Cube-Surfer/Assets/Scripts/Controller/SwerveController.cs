using UnityEngine;
using UnityEngine.EventSystems;

public class SwerveController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField] private Transform swerveParent; // Oyuncu modelinin transform bileþeni.
	[SerializeField] private Transform minClampTr; 
	[SerializeField] private Transform maxClampTr;

	[SerializeField] float moveSensitivity; //Hareket hassasiyetini kontrol eden bir hassasiyet deðeri. 

	private Vector2 moveLastPos; //Son konumunu depolayan bir vektör.
	private PointerEventData mousePosHolder; //Fare pozisyonunu tutan bir PointerEventData nesnesi.

	//IDragHandler arayüzünden gelen yöntem, fare sürükleme olayýný iþler.
	public void OnDrag(PointerEventData eventData)
	{
		mousePosHolder = eventData;
		//'TouchDetectionMovement' metodunu çaðýrarak fare hareketini iþler.
		TouchDetectionMovement(mousePosHolder);
		//CLAMP ile kýsýtlamayý uygular.
		Clamp();
	}

	//Fare sürükleme hareketini iþleyen özel bir metot.
	private void TouchDetectionMovement(PointerEventData eventData)
	{
		//'moveLastPos''i kontrol ederek fark vektörünü hesaplar ve oyuncu modelini günceller.
		if (moveLastPos == Vector2.zero) moveLastPos = eventData.position;

		Vector2 difVec = eventData.position - moveLastPos;

		//MOVEMENT
		if (swerveParent != null)
		{
			swerveParent.localPosition += Vector3.right * difVec.x * moveSensitivity;

			moveLastPos = eventData.position;
		}
	}

	//IPointerUpHandler arayüzünden gelen yöntem, fare týklama býrakma olayýný iþler.
	public void OnPointerUp(PointerEventData eventData)
	{
		moveLastPos = Vector2.zero;

		if (mousePosHolder != null)
		{
			mousePosHolder.position = Vector2.zero;
		}
	}
	//IPointerDownHandler arayüzüne gelen yöntem, fare týklama olayýný iþler.
	public void OnPointerDown(PointerEventData eventData)
	{
		//'mousePosHolder''a fare pozisyonunu atar.
		mousePosHolder = eventData;
	}

	//Player'ýn pozisyonunu belirli sýnýrlar içinde kýsýtlayan bir metot.
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