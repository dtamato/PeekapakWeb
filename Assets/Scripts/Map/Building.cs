﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Building : MonoBehaviour {

    public enum LocationType { EMOTIONAL_JOURNEY, EMOTIONAL_MATCH };
    [SerializeField] LocationType locationType;

	[SerializeField] GameObject interior;
	[SerializeField] GameObject textPanel;
    [Tooltip ("Use this string to set the PlayerPref Location. EJ:  OR EM: Statue, School, TOG")] 
    [SerializeField] string destinationName;

	[SerializeField] bool isUnlocked = false;

	void Update () {

		if(Input.GetKeyDown(KeyCode.Q)) {

			isUnlocked = true;
		}
	}

	public void OpenBuilding () {
       
		if(isUnlocked) {

            // interior.SetActive(true);
            PlayerPrefs.SetString("Location", destinationName);
            CheckLocationType();
		}
		else {

			textPanel.SetActive(true);
			textPanel.GetComponentInChildren<Text>().text = "Seems to be closed...";
		}
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

    void OpenEmotionalMatchGame() {
        SceneManager.LoadScene("Emotional Match Game 2.0");
    }

    void OpenEmotionalJourneyGame() {
        SceneManager.LoadScene("Emotional Journey 2.0");
    }
}
