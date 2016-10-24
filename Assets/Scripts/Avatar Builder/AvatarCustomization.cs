using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class AvatarCustomization : MonoBehaviour {

    [Header("Avatar Preview Images")]
	[SerializeField] Image hairAImage;
	[SerializeField] Image hairBImage;
	[SerializeField] Image headImage;
	[SerializeField] Image bodyImage;
	[SerializeField] Image eyesImage;
	[SerializeField] Image topImage;
	[SerializeField] Image bottomsImage;
    [SerializeField] Image shoesImage;

    [Header("Grids")]
	[SerializeField] GameObject hairGrid;
	[SerializeField] GameObject skinGrid;
    [SerializeField] GameObject eyesGrid;
    [SerializeField] GameObject topGrid;
    [SerializeField] GameObject bottomsGrid;
    [SerializeField] GameObject shoesGrid; 

	
    void OnEnable () {
        
        //HideAllGrids();
    }

    void HideAllGrids () {
		        
        hairGrid.SetActive(false);
		skinGrid.SetActive(false);
		eyesGrid.SetActive(false);
        topGrid.SetActive(false);
		bottomsGrid.SetActive(false);
        shoesGrid.SetActive(false);
    }

    public void ToggleGrid (GameObject gridToToggle) {

        if (gridToToggle.activeSelf) {

            gridToToggle.SetActive(false);
        }
        else {

            //HideAllGrids();
            gridToToggle.SetActive(!gridToToggle.activeSelf);
        }
    }

	public void SwitchHair () {


	}

	public void SwitchSkin () {

		headImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
		bodyImage.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}

	public void SwitchEyes () {

		eyesImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
	}

	public void SwitchTop () {

		topImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
	}

	public void SwitchBottoms () {

		bottomsImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
	}

    public void SwitchShoes () {

		shoesImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
    }
}
