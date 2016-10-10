using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Emotions : MonoBehaviour {

    string emotion;
    int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag() {
        Debug.Log("Dragging");
        transform.localPosition = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), this.transform.localPosition.z);
    }

    public void Initialize(string newEmotion, int newID) {
        emotion = newEmotion;
        id = newID;
        // if (this.GetComponentInChildren<Text>()) { this.GetComponentInChildren<Text>().text = emotion; }
    }

    public void SetText() {
        this.GetComponentInChildren<Text>().text = emotion;
    }

    public string GetEmotion() {
        return emotion;
    }

    public int GetID() {
        return id;
    }
}
