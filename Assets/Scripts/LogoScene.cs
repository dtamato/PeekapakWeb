using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		StartCoroutine (LoadNextScene ());
	}
	
	IEnumerator LoadNextScene () {


		yield return new WaitForSeconds (1.5f);

		SceneManager.LoadScene ("Map");
	}
}
