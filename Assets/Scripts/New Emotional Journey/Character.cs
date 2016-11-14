using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    
    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject characterGlow;
    [SerializeField] GameObject[] images;

    bool tapped = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick() {
        if (!tapped) {
            Debug.Log("Tapping");
            speechBubble.SetActive(true);
            tapped = true;
        }
    }

    public void SetTapped(bool newState) {
        tapped = newState;
    }

    public void OnPointerEnter() {
        if (!tapped) { 
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
}
