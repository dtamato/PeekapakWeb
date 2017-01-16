using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class AvatarCustomization : MonoBehaviour {

	[Header("Hair")]
	[SerializeField] GameObject hairPanel;
	[SerializeField] GameObject hairColorPanel;

	[Header("Eyes")]
	[SerializeField] GameObject eyePanel;
	[SerializeField] GameObject eyeColorPanel;

	[Header("Skin")]
	[SerializeField] GameObject skinPanel;

	[Header("Top")]
	[SerializeField] GameObject topsPanel;
	[SerializeField] GameObject topsColorPanel;

	[Header("Bottoms")]
	[SerializeField] GameObject bottomsPanel;
	[SerializeField] GameObject bottomsColorPanel;

	[Header("Shoes")]
	[SerializeField] GameObject shoePanel;
	[SerializeField] GameObject shoeColorPanel;

	[Header("Accessory")]
	[SerializeField] GameObject accessoryPanel;
	[SerializeField] GameObject accessoryColorPanel;

	GameObject[] panelsArray = new GameObject[13];


	void Awake () {

		panelsArray[0] = hairPanel;
		panelsArray[1] = hairColorPanel;
		panelsArray[2] = eyePanel;
		panelsArray[3] = eyeColorPanel;
		panelsArray[4] = skinPanel;
		panelsArray[5] = topsPanel;
		panelsArray[6] = topsColorPanel;
		panelsArray[7] = bottomsPanel;
		panelsArray[8] = bottomsColorPanel;
		panelsArray[9] = shoePanel;
		panelsArray[10] = shoeColorPanel;
		panelsArray[11] = accessoryPanel;
		panelsArray[12] = accessoryColorPanel;

		CloseAllPanels ();
		OpenHairsPanel ();
	}

	void CloseAllPanels () {

		for (int i = 0; i < panelsArray.Length; i++) {

			panelsArray [i].SetActive (false);
		}
	}

	public void OpenHairsPanel () {

		CloseAllPanels ();
		hairPanel.SetActive (true);
		hairColorPanel.SetActive (true);
	}

	public void OpenEyesPanel () {

		CloseAllPanels ();
		eyePanel.SetActive (true);
		eyeColorPanel.SetActive (true);
	}

	public void OpenSkinsPanel () {

		CloseAllPanels ();
		skinPanel.SetActive (true);
	}
		
	public void OpenTopsPanel () {

		CloseAllPanels ();
		topsPanel.SetActive (true);
		topsColorPanel.SetActive(true);
	}
		
	public void OpenBottomsPanel () {

		CloseAllPanels ();
		bottomsPanel.SetActive (true);
		bottomsColorPanel.SetActive(true);
	}
		
	public void OpenShoesPanel () {

		CloseAllPanels ();
		shoePanel.SetActive (true);
		shoeColorPanel.SetActive(true);
	}

	public void OpenAccessoriesPanel () {

		CloseAllPanels ();
		accessoryPanel.SetActive (true);
		accessoryColorPanel.SetActive(true);
	}

	public void SaveAvatar () {

		GameObject avatarSaver = GameObject.FindGameObjectWithTag ("Avatar Saver");

		if (avatarSaver) {

			avatarSaver.GetComponent<AvatarSaver> ().SaveData (this.gameObject);
		}
	}
}
