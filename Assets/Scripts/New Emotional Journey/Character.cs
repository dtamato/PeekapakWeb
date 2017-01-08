using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    
    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject characterGlow;
    [SerializeField] GameObject[] images;

    bool tapped = false;

    public void OnPointerClick() {
        if (!tapped) {
            // Debug.Log("Tapping");
            speechBubble.SetActive(true);
            tapped = true;
        }
    }

    public void SetTapped(bool newState) {
        tapped = newState;
    }

    public void OnPointerEnter() {
        if (!tapped) {
            // tapped = true;
            characterGlow.SetActive(true);
        }
    }

    public void OnPointerExit() {
        characterGlow.SetActive(false);
    }

    public void ChangeImage(int stage) {
        // Debug.Log("Stage: " + stage);
        for (int i = 0; i < images.Length; i++) {
            if (stage == i) { images[i].SetActive(true); } 
            else { images[i].SetActive(false); }
        }
    }

    // This will be called from this games controller and pass in the right sprites for the location
    public void SetImageList(Sprite[] newImages, Sprite newCharacterGlow) {
        // Fill the character Sprite Sheet
        for (int i = 0; i < newImages.Length; i++) {
            images[i].GetComponent<Image>().sprite = newImages[i];
        }
        // Set the Glow
        characterGlow.GetComponent<Image>().sprite = newCharacterGlow;
    }

    public void ToggleTapped() {
        tapped = true;
    }
}
