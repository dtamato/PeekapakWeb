using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class AvatarCustomization : MonoBehaviour {

	[Header("Hair")]
	[SerializeField] Image hairFrontImage;
	[SerializeField] Image hairBackImage;
	[SerializeField] GameObject hairsPanel;
	[SerializeField] GameObject hairsColorPanel;

	[Header("Eyes")]
	[SerializeField] Image eyesImage;
	[SerializeField] GameObject eyesPanel;
	[SerializeField] GameObject eyesColorPanel;

	[Header("Skin")]
	[SerializeField] Image headImage;
	[SerializeField] Image bodyImage;
	[SerializeField] GameObject skinsPanel;

	[Header("Top")]
	[SerializeField] Image topImage;
	[SerializeField] GameObject topsPanel;

	[Header("Bottoms")]
	[SerializeField] Image bottomsImage;
	[SerializeField] GameObject bottomsPanel;

	[Header("Shoes")]
	[SerializeField] Image shoesImage;
	[SerializeField] GameObject shoesPanel;

	[Header("Nose")]
	[SerializeField] Image noseImage;
	[SerializeField] GameObject nosesPanel;

	[Header("Mouth")]
	[SerializeField] Image mouthImage;
	[SerializeField] GameObject mouthsPanel;

	[Header("Accessory")]
	[SerializeField] Image accessoryImage;
	[SerializeField] GameObject accessoriesPanel;

	GameObject[] panelsArray = new GameObject[11];


	void Awake () {

		panelsArray[0] = hairsPanel;
		panelsArray[1] = hairsColorPanel;
		panelsArray[2] = eyesPanel;
		panelsArray[3] = eyesColorPanel;
		panelsArray[4] = skinsPanel;
		panelsArray[5] = topsPanel;
		panelsArray[6] = bottomsPanel;
		panelsArray[7] = shoesPanel;
		panelsArray[8] = nosesPanel;
		panelsArray[9] = mouthsPanel;
		panelsArray[10] = accessoriesPanel;

		CloseAllPanels ();
		OpenHairsPanel ();
	}

	void CloseAllPanels () {

		for (int i = 0; i < panelsArray.Length; i++) {

			panelsArray [i].SetActive (false);
		}
	}

	public void ChangeAvatarPart (Image imageToChange) {

		imageToChange.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().sprite;
	}

	#region HAIR
	public void OpenHairsPanel () {

		CloseAllPanels ();
		hairsPanel.SetActive (true);
		hairsColorPanel.SetActive (true);
	}

	public void ChangeHairColor () {

		hairBackImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
		hairFrontImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
	}
	#endregion

	#region EYES
	public void OpenEyesPanel () {

		CloseAllPanels ();
		eyesPanel.SetActive (true);
		eyesColorPanel.SetActive (true);
	}

	public void ChangeEyeColor () {

		eyesImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
	}
	#endregion

	#region SKIN
	public void OpenSkinsPanel () {

		CloseAllPanels ();
		skinsPanel.SetActive (true);
	}

	public void ChangeSkin () {

		headImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
		bodyImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}
	#endregion

	#region TOP
	public void OpenTopsPanel () {

		CloseAllPanels ();
		topsPanel.SetActive (true);
	}
	#endregion

	#region BOTTOM
	public void OpenBottomsPanel () {

		CloseAllPanels ();
		bottomsPanel.SetActive (true);
	}
	#endregion

	#region SHOES
	public void OpenShoesPanel () {

		CloseAllPanels ();
		shoesPanel.SetActive (true);
	}
	#endregion

	#region NOSE
	public void OpenNosesPanel () {

		CloseAllPanels ();
		nosesPanel.SetActive (true);
	}
	#endregion

	#region MOUTH
	public void OpenMouthsPanel () {

		CloseAllPanels ();
		mouthsPanel.SetActive (true);
	}
	#endregion

	#region ACCESSORY
	public void OpenAccessoriesPanel () {

		CloseAllPanels ();
		accessoriesPanel.SetActive (true);
	}
	#endregion
}
