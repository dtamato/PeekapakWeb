using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class AvatarCustomization : MonoBehaviour {

	[Header("Avatar References")]
	[SerializeField] Image headImage;
	[SerializeField] Image bodyImage;

	[Header("Panels")]
	[SerializeField] GameObject hairsPanel;
	[SerializeField] GameObject eyesPanel;
	[SerializeField] GameObject eyesColorPanel;
	[SerializeField] GameObject skinsPanel;
	[SerializeField] GameObject topsPanel;
	[SerializeField] GameObject bottomsPanel;
	[SerializeField] GameObject shoesPanel;
	[SerializeField] GameObject nosesPanel;
	[SerializeField] GameObject mouthsPanel;
	[SerializeField] GameObject accessoriesPanel;

	GameObject[] panelsArray = new GameObject[10];


	void Awake () {

		panelsArray[0] = hairsPanel;
		panelsArray[1] = eyesPanel;
		panelsArray[2] = eyesColorPanel;
		panelsArray[3] = skinsPanel;
		panelsArray[4] = topsPanel;
		panelsArray[5] = bottomsPanel;
		panelsArray[6] = shoesPanel;
		panelsArray[7] = nosesPanel;
		panelsArray[8] = mouthsPanel;
		panelsArray[9] = accessoriesPanel;
	}

	void CloseAllPanels () {

		for (int i = 0; i < panelsArray.Length; i++) {

			panelsArray [i].SetActive (false);
		}
	}

	public void OpenHairsPanel () {

		CloseAllPanels ();
	}

	public void OpenEyesPanel () {

		CloseAllPanels ();
		eyesPanel.SetActive (true);
		eyesColorPanel.SetActive (true);
	}

	public void OpenSkinsPanel () {

		CloseAllPanels ();
		skinsPanel.SetActive (true);
	}

	public void ChangeSkin () {

		headImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
		bodyImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}

	public void OpenTopsPanel () {

		CloseAllPanels ();
	}

	public void OpenBottomsPanel () {

		CloseAllPanels ();
	}

	public void OpenShoesPanel () {

		CloseAllPanels ();
	}

	public void OpenNosesPanel () {

		CloseAllPanels ();
	}

	public void OpenMouthsPanel () {

		CloseAllPanels ();
	}

	public void OpenAccessoriesPanel () {

		CloseAllPanels ();
	}
}
