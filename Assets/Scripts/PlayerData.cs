using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	static int berryCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetLocation(string newLocation) {
        PlayerPrefs.SetString("Location", newLocation);
    }

	public static int GetBerryCount () {

		return berryCount;
	}

	public static void AddBerries (int amount) {

		berryCount += amount;
	}
}
