using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class MapCharacter : MonoBehaviour {

	[Header("Camera Targets")]
	[SerializeField] float targetCameraSize;
	[SerializeField] Vector3 targetCameraPosition;

	[Header("References")]
	[SerializeField] GameObject speechBubble;

	MapCameraController cameraController;
	float initialCameraSize;
	Vector3 initialCameraPosition;

	void Awake () {

		// Initialize
		speechBubble.SetActive(false);
		cameraController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MapCameraController>();
	}

	public void StartConversation () {

		// Save camera data
		initialCameraSize = Camera.main.orthographicSize;
		initialCameraPosition = Camera.main.transform.position;

		cameraController.SetCanMove(false);
		this.GetComponentInChildren<Button>().interactable = false;
		this.GetComponentInChildren<EventTrigger>().enabled = false;
		speechBubble.SetActive(true);

		cameraController.StopAllCoroutines();
		cameraController.StartCoroutine("ZoomCamera", targetCameraSize);

		float newX = this.transform.position.x + 100;
		float newY = Mathf.Clamp(this.transform.position.y, 20, 1000);
		Vector3 newPosition = new Vector3(newX, newY, -10);
		cameraController.StartCoroutine("MovePosition", newPosition);
	}

	public void LeaveConversation () {

		this.GetComponentInChildren<Button>().interactable = true;
		this.GetComponentInChildren<EventTrigger>().enabled = true;
		speechBubble.SetActive(false);
		this.transform.GetChild(0).gameObject.SetActive(false);

		cameraController.StopAllCoroutines();
		cameraController.StartCoroutine("ZoomCamera", initialCameraSize);
		cameraController.StartCoroutine("MovePosition", initialCameraPosition);
		cameraController.SetCanMove(true);
	}
}
