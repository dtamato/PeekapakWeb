using UnityEngine;
using UnityEngine.EventSystems;
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

	public void ToggleMusicPlaying () {

		AudioSource audioSource = this.GetComponent<AudioSource> ();
		GameObject muteIcon = EventSystem.current.currentSelectedGameObject.transform.FindChild("Mute Icon").gameObject;

		if (audioSource.isPlaying) {

			audioSource.Pause();
			muteIcon.SetActive (true);
		}
		else {

			audioSource.Play ();
			muteIcon.SetActive (false);
		}
	}
}
