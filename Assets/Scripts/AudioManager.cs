using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;


	void Awake () {

		// Singleton control
		if (instance == null) {

			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else if (instance != this) {

			Destroy (this.gameObject);
		}
	}
}
