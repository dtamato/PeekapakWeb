using UnityEngine;
using UnityEngine.UI;

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

		this.GetComponent<Button>().interactable = false;
		speechBubble.SetActive(true);

		cameraController.StopAllCoroutines();
		cameraController.StartCoroutine("ZoomCamera", targetCameraSize);
		cameraController.StartCoroutine("MovePosition", targetCameraPosition);
	}

	public void LeaveConversation () {

		this.GetComponent<Button>().interactable = true;
		speechBubble.SetActive(false);

		cameraController.StopAllCoroutines();
		cameraController.StartCoroutine("ZoomCamera", initialCameraSize);
		cameraController.StartCoroutine("MovePosition", initialCameraPosition);
	}
}
