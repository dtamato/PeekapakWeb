using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    
    [SerializeField] GameObject speechBubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick() {
        speechBubble.SetActive(true);
    }
}
