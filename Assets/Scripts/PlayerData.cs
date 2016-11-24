using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetLocation(string newLocation) {
        PlayerPrefs.SetString("Location", newLocation);
    }
}
