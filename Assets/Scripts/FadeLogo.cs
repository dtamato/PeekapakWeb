using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class FadeLogo : MonoBehaviour {

	[SerializeField, Range(0.1f, 1f)] float fadeInSpeed;
	[SerializeField, Range(0.1f, 1f)] float fadeOutSpeed;
	[SerializeField] string sceneToLoad;

	SpriteRenderer spriteRenderer;
	bool fadingIn;

	void Start () {
	
		spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
		spriteRenderer.color = new Color(1, 1, 1, 0);
		fadingIn = true;
	}

	void Update () {

		float alpha = spriteRenderer.color.a;

		if(fadingIn) {
			
			if(alpha < 1) {

				alpha += fadeInSpeed * Time.deltaTime;
				spriteRenderer.color = new Color(1, 1, 1, alpha);
			}
			else {

				fadingIn = false;
			}
		}
		else {

			if(alpha > 0) {

				alpha -= fadeOutSpeed * Time.deltaTime;
				spriteRenderer.color = new Color(1, 1, 1, alpha);
			}
			else {

				SceneManager.LoadScene(sceneToLoad);
			}
		}
	}
}
