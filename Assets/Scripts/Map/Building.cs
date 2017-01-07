using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {

    public enum LocationType { EMOTIONAL_JOURNEY, EMOTIONAL_MATCH };
    [SerializeField] LocationType locationType;

	[SerializeField] GameObject interior;
	[SerializeField] GameObject textPanel;
    [SerializeField] string destinationName;

	bool isUnlocked = false;

	void Update () {

		if(Input.GetKeyDown(KeyCode.Q)) {

			isUnlocked = true;
		}
	}

	public void OpenBuilding () {

		if(isUnlocked) {

			interior.SetActive(true);
		}
		else {

			textPanel.SetActive(true);
			textPanel.GetComponentInChildren<Text>().text = "Seems to be closed...";
		}
	}
}
