using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Faces : MonoBehaviour {

    Sprite face;
    int id;
    int matchCount = 0;

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

    public void IncreaseMatchCount() {
        matchCount++;
        if (matchCount == 2) {
            this.GetComponent<Image>().enabled = false;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
