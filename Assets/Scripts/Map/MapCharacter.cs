using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

[DisallowMultipleComponent]
public class MapCharacter : MonoBehaviour {

    public enum LocationType { EMOTIONAL_MATCH, EMOTIONAL_JOURNEY };
    [SerializeField] LocationType locationType;

	[Header("Camera Targets")]
	[SerializeField] float targetCameraSize;
	[SerializeField] Vector3 targetCameraPosition;

	[Header("References")]
	[SerializeField] GameObject speechBubble;
    [SerializeField] GameObject completedButton;
    [SerializeField] GameObject incompleteButtons;
    [SerializeField] GameObject happyCharacterImage;
    [SerializeField] GameObject sadCharacterImage;

    [Tooltip("Used to Set Player Prefs Loaction. Can use: Leo's Home, Library, School Hallway, TOG, Statue, School")]
    [SerializeField] string destinationName;
    [Tooltip("Use this to decide which PlaerPref to check for success. eg. Solved_ScoolMG or Solved_LibraryEJ")]
    [SerializeField] string successCheck;

	MapCameraController cameraController;
	float initialCameraSize;
	Vector3 initialCameraPosition;

	void Awake () {
		// Initialize
		speechBubble.SetActive(false);
		cameraController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MapCameraController>();
        SuccessCheck();
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
        if(PlayerPrefs.GetInt(successCheck) == 0) { 
		    sadCharacterImage.GetComponentInChildren<Button>().interactable = true;
		    sadCharacterImage.GetComponentInChildren<EventTrigger>().enabled = true;
        } else { 
            happyCharacterImage.GetComponentInChildren<Button>().interactable = true;
            happyCharacterImage.GetComponentInChildren<EventTrigger>().enabled = true;
        }
        speechBubble.SetActive(false);
		// this.transform.GetChild(0).gameObject.SetActive(false);

		cameraController.StopAllCoroutines();
		cameraController.StartCoroutine("ZoomCamera", initialCameraSize);
		cameraController.StartCoroutine("MovePosition", initialCameraPosition);
		cameraController.SetCanMove(true);
	}

    void CheckLocationType() {
        switch (locationType) {
            case LocationType.EMOTIONAL_JOURNEY:
                OpenEmotionalJourneyGame();
                break;
            case LocationType.EMOTIONAL_MATCH:
                OpenEmotionalMatchGame();
                break;
        }
    }

    void SuccessCheck() {
         // Check to see if this game has been beaten already
        if (PlayerPrefs.GetInt(successCheck) == 1) {
            // Debug.Log("Game Beaten");
            speechBubble.GetComponentInChildren<Text>().text = "Thanks so much for helping me!";
            completedButton.SetActive(true);
            incompleteButtons.SetActive(false);
            sadCharacterImage.SetActive(false);
            happyCharacterImage.SetActive(true);
        }
    }

    void OpenEmotionalMatchGame() {
        SceneManager.LoadScene("Emotional Match Game 2.0");
    }

    void OpenEmotionalJourneyGame() {
        SceneManager.LoadScene("Emotional Journey 2.0");
    }

    public void HelpCharacter() {
        PlayerPrefs.SetString("Location", destinationName);
        CheckLocationType();
    }
}
