using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Faces : MonoBehaviour {

    Sprite face;
    int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(Sprite newFace, int newID) {
        face = newFace;
        id = newID;
        // if (this.GetComponent<Image>()) { this.GetComponent<Image>().sprite = face; }
    }

    public void SetFaceImage() {
        this.GetComponent<Image>().sprite = face;
    }

    public Sprite GetFace() {
        return face;
    }

    public int GetID() {
        return id;
    }
}
