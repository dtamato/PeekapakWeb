using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class InEditorFontReplacer : MonoBehaviour {

	[SerializeField] Font newFont;

	void Start () {
	
		if(newFont) {

			Text[] allTextObjects = GameObject.FindObjectOfType<Canvas>().GetComponentsInChildren<Text>();
			foreach (Text textObject in allTextObjects) {

				textObject.font = newFont;
			}
		}
	}
}
