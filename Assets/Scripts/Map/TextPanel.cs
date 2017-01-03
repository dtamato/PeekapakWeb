using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class TextPanel : MonoBehaviour {

	MapCameraController cameraController;


	void Awake () {

		cameraController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MapCameraController>();
	}

	void OnEnable () {

		cameraController.SetCanMove(false);
	}

	void OnDisable () {

		cameraController.SetCanMove(true);
	}
}
