using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IceCreamParlor : MonoBehaviour {

	[SerializeField] GameObject parlorInterior;
	[SerializeField] GameObject textPanel;

	bool isUnlocked = false;


	void Update () {

		if(Input.GetKeyDown(KeyCode.Q)) {

			isUnlocked = true;
		}
	}

	public void OpenParlor () {

		if(isUnlocked) {

			parlorInterior.SetActive(true);
		}
		else {

			textPanel.SetActive(true);
			textPanel.GetComponentInChildren<Text>().text = "Seems to be closed...";
		}
	}
}
