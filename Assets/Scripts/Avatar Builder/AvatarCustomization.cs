using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class AvatarCustomization : MonoBehaviour {

    [Header("Avatar Preview Images")]
    [SerializeField] Image shoesImage;

    [Header("Grids")]
    [SerializeField] GameObject skinGrid;
    [SerializeField] GameObject hairGrid;
    [SerializeField] GameObject eyesGrid;
    [SerializeField] GameObject topGrid;
    [SerializeField] GameObject bottomGrid;
    [SerializeField] GameObject shoesGrid; 

	
    void OnEnable () {
        
        HideAllGrids();
    }

    void HideAllGrids () {

        skinGrid.SetActive(false);
        hairGrid.SetActive(false);
        eyesGrid.SetActive(false);
        topGrid.SetActive(false);
        bottomGrid.SetActive(false);
        shoesGrid.SetActive(false);
    }

    public void ToggleGrid (GameObject gridToToggle) {

        if (gridToToggle.activeSelf) {

            gridToToggle.SetActive(false);
        }
        else {

            HideAllGrids();
            gridToToggle.SetActive(!gridToToggle.activeSelf);
        }
    }

    public void UpdateShoes () {

        Sprite newShoeSprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        if(newShoeSprite) {

            shoesImage.sprite = newShoeSprite;
        }
    }
}
