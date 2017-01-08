using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
    string firstOpen;

	// Use this for initialization
	void Start () {
        firstOpen = PlayerPrefs.GetString("firstOpen");
        // If this is the first time opening the game
        if (firstOpen != "false") {
            PlayerPrefs.SetString("firstOpen", "false");
            SetUpPlayerData();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetUpPlayerData() {
        // Set the location to be map 
        PlayerPrefs.SetString("Location", "Map");
        // Default the berries to 0
        PlayerPrefs.SetInt("berryCount", 0);

        // Set all "solved" bools to false - 1 = true 0 = false
        // Emotional Journey
        PlayerPrefs.SetInt("Solved_LeosHomeEJ", 0);
        PlayerPrefs.SetInt("Solved_LibraryEJ", 0);
        PlayerPrefs.SetInt("Solved_SchoolHallwayEJ", 0);
        PlayerPrefs.SetInt("Solved_TreeOfGratitudeEJ", 0);

        // Match Game
        PlayerPrefs.SetInt("Solved_StatueMG", 0);
        PlayerPrefs.SetInt("Solved_SchoolMG", 0);
        PlayerPrefs.SetInt("Solved_TreeOfGratitudeMG", 0);

    }

    public void SetLocation(string newLocation) {
        PlayerPrefs.SetString("Location", newLocation);
    }
}
