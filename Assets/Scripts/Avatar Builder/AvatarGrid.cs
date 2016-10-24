using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class AvatarGrid : MonoBehaviour {


	void Start () {

		// Ensure grid is initialized properly
		this.gameObject.SetActive(true);
		this.GetComponent<RectTransform>().localPosition = new Vector3(193, -22, 0);
		this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 180, 0);
		this.GetComponentInChildren<Canvas>().sortingOrder = -1;
		this.gameObject.SetActive(false);
	}

	// Called as an Animation Event
	public void ChangeSortingLayer(int newLayer) {

		this.GetComponentInChildren<Canvas>().sortingOrder = newLayer;
	}

	public void StartCloseAnimation () {

		this.GetComponentInChildren<Animator>().SetTrigger("Close");
	}

	// Called as an Animation Event
	public void CloseGrid () {

		this.gameObject.SetActive(false);
	}
}
