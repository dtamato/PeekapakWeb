using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MapLeo : MonoBehaviour {

	[Header("Camera Position")]
	[SerializeField] float targetCameraSize;
	[SerializeField] Vector3 targetCameraPosition;

	[Header("References")]
	[SerializeField] GameObject speechBubble;

	float initialCameraSize;
	Vector3 initialCameraPosition;

	public void StartConversation () {

		this.GetComponent<Button>().interactable = false;
		speechBubble.SetActive(true);

		initialCameraSize = Camera.main.orthographicSize;
		initialCameraPosition = Camera.main.transform.position;

		// TODO: Trigger animation to zoom in and reposition camera

	}

	public void LeaveConversation () {

		this.GetComponent<Button>().interactable = true;
		speechBubble.SetActive(false);
	}
}
