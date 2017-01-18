using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class MapCameraController : MonoBehaviour {

	[Header("Movement Parameters")]
	[SerializeField] float leftBoundary = -6702;
	[SerializeField] float rightBoundary = 0;
	[SerializeField] float farTreesMoveSpeed = 0.5f;
	[SerializeField] float closeTreesMoveSpeed = 1;
	[SerializeField] float streetMoveSpeed = 1;

	[Header("Parallaxing Layers")]
	[SerializeField] RectTransform farTreesRectTransform;
	[SerializeField] RectTransform closeTreesRectTranform;
	[SerializeField] RectTransform streetRectTransform;

	[Header("References")]
	[SerializeField] GameObject playerHUD;

	[Header("Location Positions")]
	[SerializeField] float leoHomeXPosition;
	[SerializeField] float libraryXPosition;
	[SerializeField] float treeOfGratitudeXPosition;
	[SerializeField] float statueXPosition;
	[SerializeField] float schoolXPosition;
	[SerializeField] float schoolHallXPosition;

	bool canMove = true;
	bool moveLeft = false;
	bool moveRight = false;

	void Awake () {

		streetRectTransform.localPosition = new Vector3 (rightBoundary, streetRectTransform.localPosition.y, streetRectTransform.localPosition.z);
		closeTreesRectTranform.localPosition = new Vector3(rightBoundary, closeTreesRectTranform.localPosition.y, closeTreesRectTranform.localPosition.z);
		farTreesRectTransform.localPosition = new Vector3(rightBoundary, farTreesRectTransform.localPosition.y, farTreesRectTransform.localPosition.z);
	}

	void OnEnable () {

		// Move to location of last game
		string lastLocation = PlayerPrefs.GetString ("Location");

		if (lastLocation == "Library") {

			streetRectTransform.localPosition = new Vector3 (libraryXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (libraryXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (libraryXPosition, 0, 0);
		}
		else if (lastLocation == "Leo's Home") {

			streetRectTransform.localPosition = new Vector3 (leoHomeXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (leoHomeXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (leoHomeXPosition, 0, 0);
		}
		else if (lastLocation == "School Hallway") {

			streetRectTransform.localPosition = new Vector3 (schoolHallXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (schoolHallXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (schoolHallXPosition, 0, 0);
		}
		else if (lastLocation == "TOG") {

			streetRectTransform.localPosition = new Vector3 (treeOfGratitudeXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (treeOfGratitudeXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (treeOfGratitudeXPosition, 0, 0);
		}
		else if (lastLocation == "School") {

			streetRectTransform.localPosition = new Vector3 (schoolXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (schoolXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (schoolXPosition, 0, 0);
		}
		else if (lastLocation == "Statue") {

			streetRectTransform.localPosition = new Vector3 (statueXPosition, 0, 0);
			closeTreesRectTranform.localPosition = new Vector3 (statueXPosition, 0, 0);
			farTreesRectTransform.localPosition = new Vector3 (statueXPosition, 0, 0);
		}
		else {

			streetRectTransform.localPosition = Vector3.zero;
			closeTreesRectTranform.localPosition = Vector3.zero;
			farTreesRectTransform.localPosition = Vector3.zero;
		}
	}

	void Update () {
	
		if (canMove) {

			if (Input.GetAxis ("Horizontal") != 0) {

				MoveCamera (Input.GetAxis ("Horizontal"));
			}
			else if (moveLeft) {
				
				MoveCamera (-1);
			}
			else if (moveRight) {

				MoveCamera (1);
			}
		}
	}

	IEnumerator ZoomCamera (float newSize) {

		if(newSize < Camera.main.orthographicSize) { playerHUD.SetActive(false); }

		while(Mathf.Abs(Camera.main.orthographicSize - newSize) > 0.5f) {

			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, 3 * Time.deltaTime);
			yield return null;
		}

		if(newSize > Camera.main.orthographicSize) { playerHUD.SetActive(true); }
		Camera.main.orthographicSize = newSize;
		StopAllCoroutines();
	}

	IEnumerator MovePosition (Vector3 newPosition) {

		while(Vector3.Distance(streetRectTransform.position, newPosition) > 0.5f) {

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPosition, 3 * Time.deltaTime);
			yield return null;
		}

		Camera.main.transform.position = newPosition;
	}

	public void MoveCamera (float direction) {
			
		// Move street
		streetRectTransform.Translate (direction * streetMoveSpeed * Vector3.left);

		float newStreetX = streetRectTransform.localPosition.x;
		newStreetX = Mathf.Clamp (newStreetX, leftBoundary, rightBoundary);

		streetRectTransform.localPosition = new Vector3 (newStreetX, streetRectTransform.localPosition.y, streetRectTransform.localPosition.z);

		// Move trees
		if (streetRectTransform.localPosition.x > leftBoundary && streetRectTransform.localPosition.x < rightBoundary) {

			closeTreesRectTranform.Translate (direction * closeTreesMoveSpeed * Vector3.left);
			farTreesRectTransform.Translate (direction * farTreesMoveSpeed * Vector3.left);

			float newFarTreesX = farTreesRectTransform.localPosition.x;
			float newCloseTreesX = closeTreesRectTranform.localPosition.x;

			closeTreesRectTranform.localPosition = new Vector3 (newCloseTreesX, closeTreesRectTranform.localPosition.y, closeTreesRectTranform.localPosition.z);
			farTreesRectTransform.localPosition = new Vector3 (newFarTreesX, farTreesRectTransform.localPosition.y, farTreesRectTransform.localPosition.z);
		}
	}

	public void SetCanMove(bool newValue) {

		canMove = newValue;
	}

	public void ToggleMoveLeft () {

		moveLeft = !moveLeft;
	}

	public void ToggleMoveRight () {

		moveRight = !moveRight;
	}
}
