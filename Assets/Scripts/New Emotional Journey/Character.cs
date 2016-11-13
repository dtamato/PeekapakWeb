using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    
    [SerializeField] GameObject speechBubble;

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
}
