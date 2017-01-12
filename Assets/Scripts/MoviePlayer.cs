using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[DisallowMultipleComponent]
public class MoviePlayer : MonoBehaviour {

	[SerializeField] string sceneToLoad;

	Renderer renderer;
	MovieTexture movieTexture;

	void Start () {
	
		renderer = this.GetComponent<Renderer> ();
		movieTexture = (MovieTexture)renderer.material.mainTexture;

		if (!movieTexture.isPlaying) {

			movieTexture.Play ();
		}

		StartCoroutine (LoadNextScene ());
	}

	IEnumerator LoadNextScene () {


		yield return new WaitForSeconds (movieTexture.duration + 0.5f);

		SceneManager.LoadScene (sceneToLoad);
	}
}
