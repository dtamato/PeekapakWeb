using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class EyeCustomization : MonoBehaviour {
	
	[SerializeField] Image avatarEyes;
	[SerializeField] GameObject[] eyeTypes;
	[SerializeField] Sprite[] type1Eyes;
	[SerializeField] Sprite[] type2Eyes;
	[SerializeField] Sprite[] type3Eyes;

	int currentEyeType = 0;
	int currentEyeColor = 0;

	Sprite[][] eyeGrid;


	void Awake () {

		eyeGrid = new Sprite[eyeTypes.Length][];
		eyeGrid[0] = type1Eyes;
		eyeGrid[1] = type2Eyes;
		eyeGrid[2] = type3Eyes;
	}

	public void ChangeEyeType (int newEyeTypeIndex) {

		currentEyeType = newEyeTypeIndex;
		UpdateEyes();
	}

	public void ChangeEyeColor (int newColorIndex) {

		currentEyeColor = newColorIndex;
		UpdateEyes();
	}

	void UpdateEyes () {

		// Update highlight
//		for(int i = 0; i < eyeTypes.Length; i++) {
//
//			eyeTypes[i].transform.GetChild(0).gameObject.SetActive(false);
//		}
//
//		eyeTypes[currentEyeType].transform.GetChild(0).gameObject.SetActive(true);

		// Update sprite
		avatarEyes.sprite = eyeGrid[currentEyeType][currentEyeColor];
	}

	public Sprite GetEyeSprite () {

		return avatarEyes.sprite;
	}
}
