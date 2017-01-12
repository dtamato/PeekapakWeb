using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class BuildingFactoid : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] string[] factoids;

	[Header("References")]
	[SerializeField] GameObject textPanel;

	int index = 0;

	public void ShowFactoid () {

		textPanel.GetComponentInChildren<Text> ().text = factoids [index];
		textPanel.SetActive (true);

		index++;
		if (index >= factoids.Length) {

			index = 0;
		}
	}
}
