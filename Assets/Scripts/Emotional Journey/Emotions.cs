using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Emotions : MonoBehaviour {

    [SerializeField]
    GameObject pointsPrefab;

    string emotion;
    int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag() {
        // Debug.Log("Dragging");
        transform.localPosition = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), this.transform.localPosition.z);
    }

    public void OnDragEnd() {
        // Debug.Log("Ending Drag");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);
        if (colliders.Length > 0) {
            // Debug.Log("Found Something");
            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].tag == "Face") {
                    // Debug.Log("Found a Face");
                    if (colliders[i].gameObject.GetComponent<Faces>().GetID() == this.id) {
                        FoundMatch(colliders, i);
                    }
                }
            }
        }
    }

    void FoundMatch(Collider2D[] colliders, int i) {
        this.gameObject.SetActive(false);
        colliders[i].GetComponent<Image>().enabled = false;
        colliders[i].transform.GetChild(0).gameObject.SetActive(true);

        // Instantiate the points - let the points control their own motion
        GameObject newPoints = Instantiate(pointsPrefab, this.transform.position, Quaternion.identity) as GameObject;
        newPoints.transform.parent = this.transform.parent;
        newPoints.transform.position = this.transform.position + new Vector3(-15, 15, 0);
        newPoints.transform.localScale = Vector3.one;
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
