using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class MapCameraController : MonoBehaviour {

	[Header("Movement Parameters")]
	[SerializeField] float moveSpeed = 1;
	[SerializeField] float leftBoundary = -250;
	[SerializeField] float rightBoundary = 6683;

	[Header("References")]
	[SerializeField] GameObject playerHUD;

	bool canMove = true;

	void Awake () {
	
		this.transform.position = new Vector3 (leftBoundary, this.transform.position.y, this.transform.position.z);
	}

	void Update () {
	
		if (canMove && Input.GetAxis ("Horizontal") != 0) {

			this.transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Vector3.right);

			float newX = this.transform.position.x;
			newX = Mathf.Clamp (newX, leftBoundary, rightBoundary);
			this.transform.position = new Vector3 (newX, this.transform.position.y, this.transform.position.z);
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

		while(Vector3.Distance(Camera.main.transform.position, newPosition) > 0.5f) {

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPosition, 2 * Time.deltaTime);
			yield return null;
		}

		Camera.main.transform.position = newPosition;
	}
}
