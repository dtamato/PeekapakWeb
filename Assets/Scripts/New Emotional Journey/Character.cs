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
            speechBubble.SetActive(true);
            tapped = true;
        }
    }
}
