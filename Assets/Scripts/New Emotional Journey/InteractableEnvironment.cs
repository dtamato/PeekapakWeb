using UnityEngine;
using System.Collections;

public class InteractableEnvironment : MonoBehaviour {

    EmotionalJourneyGameController gameController;
    [SerializeField] GameObject icon;
    [SerializeField] GameObject infoBoard;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EmotionalJourneyGameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerEnter() {
        if (gameController.GameStarted() == false && infoBoard.activeSelf == false) {
            icon.SetActive(true);
        }
    }

    public void OnPointerExit() {
        icon.SetActive(false);
    }

    public void OnPointerDown() {
        if(infoBoard.activeSelf == false && gameController.GameStarted() == false) { 
            infoBoard.SetActive(true);
            icon.SetActive(false);
        }
    }
}
