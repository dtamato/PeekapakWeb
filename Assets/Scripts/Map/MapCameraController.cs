using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class MapCameraController : MonoBehaviour {

	[Header("Movement Parameters")]
	[SerializeField] float leftBoundary = -6702;
	[SerializeField] float rightBoundary = 0;
	[SerializeField] float leftFarTreesBoundary = -4472;
	[SerializeField] float farTreesMoveSpeed = 0.5f;
	[SerializeField] float closeTreesMoveSpeed = 1;
	[SerializeField] float streetMoveSpeed = 1;

	[Header("Parallaxing Layers")]
	[SerializeField] RectTransform farTreesRectTransform;
	[SerializeField] RectTransform closeTreesRectTranform;
	[SerializeField] RectTransform streetRectTransform;

	[Header("References")]
	[SerializeField] GameObject playerHUD;

	bool canMove = true;

	void Awake () {

		streetRectTransform.localPosition = new Vector3 (rightBoundary, streetRectTransform.localPosition.y, streetRectTransform.localPosition.z);
		closeTreesRectTranform.localPosition = new Vector3(rightBoundary, closeTreesRectTranform.localPosition.y, closeTreesRectTranform.localPosition.z);
		farTreesRectTransform.localPosition = new Vector3(rightBoundary, farTreesRectTransform.localPosition.y, farTreesRectTransform.localPosition.z);
	}

	void Update () {
	
		if (canMove && Input.GetAxis ("Horizontal") != 0) {

			streetRectTransform.Translate (Input.GetAxisRaw ("Horizontal") * streetMoveSpeed * Vector3.left);
			closeTreesRectTranform.Translate (Input.GetAxisRaw ("Horizontal") * closeTreesMoveSpeed * Vector3.left);
			farTreesRectTransform.Translate (Input.GetAxisRaw ("Horizontal") * farTreesMoveSpeed * Vector3.left);

			float newFarTreesX = farTreesRectTransform.localPosition.x;
			newFarTreesX = Mathf.Clamp (newFarTreesX, leftFarTreesBoundary, rightBoundary);

			float newCloseTreesX = closeTreesRectTranform.localPosition.x;
			newCloseTreesX = Mathf.Clamp (newCloseTreesX, leftBoundary, rightBoundary);

			float newStreetX = streetRectTransform.localPosition.x;
			newStreetX = Mathf.Clamp (newStreetX, leftBoundary, rightBoundary);

			streetRectTransform.localPosition = new Vector3 (newStreetX, streetRectTransform.localPosition.y, streetRectTransform.localPosition.z);
			closeTreesRectTranform.localPosition = new Vector3 (newCloseTreesX, closeTreesRectTranform.localPosition.y, closeTreesRectTranform.localPosition.z);
			farTreesRectTransform.localPosition = new Vector3 (newFarTreesX, farTreesRectTransform.localPosition.y, farTreesRectTransform.localPosition.z);
		}
	}

	IEnumerator ZoomCamera (float newSize) {

		if(newSize < Camera.main.orthographicSize) { playerHUD.SetActive(false); }

		while(Mathf.Abs(Camera.main.orthographicSize - newSize) > 0.5f) {

			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, 2 * Time.deltaTime);
			yield return null;
		}

		if(newSize > Camera.main.orthographicSize) { playerHUD.SetActive(true); }
		Camera.main.orthographicSize = newSize;
		canMove = !canMove;
		StopAllCoroutines();
	}

	IEnumerator MovePosition (Vector3 newPosition) {

		while(Vector3.Distance(streetRectTransform.position, newPosition) > 0.5f) {

			streetRectTransform.position = Vector3.Lerp(streetRectTransform.position, newPosition, 2 * Time.deltaTime);
			closeTreesRectTranform.position = Vector3.Lerp(closeTreesRectTranform.position, newPosition, 2 * Time.deltaTime);
			farTreesRectTransform.position = Vector3.Lerp(farTreesRectTransform.position, newPosition, 2 * Time.deltaTime);
			yield return null;
		}

		streetRectTransform.position = newPosition;
		closeTreesRectTranform.position = newPosition;
		farTreesRectTransform.position = newPosition;
	}
}
