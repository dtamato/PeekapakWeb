using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Emotions : MonoBehaviour {

	GameController gameController;
    Canvas canvas;
    [SerializeField] GameObject pointsPrefab;

    string emotion;
    int id;

    bool pulse = false;
    bool grow = false;
    bool shrink = false;

    float pulseSpeed = 5;
    Vector3 minSize = new Vector3(1, 1, 1);
    Vector3 maxSize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 targetSize;

    // Use this for initialization
    void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
	}

    void Update() {
        if (pulse) {
            grow = false;
            shrink = false;
            DisplayEffect();
        }

        if (grow) {
            Grow();
        }

        if (shrink) {
            Shrink();
        }
    }
    
    void FoundMatch(Collider2D[] colliders, int i) {
        colliders[i].GetComponent<Faces>().IncreaseMatchCount();
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.position = colliders[i].transform.position;

        // Instantiate the points - let the points control their own motion
        GameObject newPoints = Instantiate(pointsPrefab, this.transform.position, Quaternion.identity) as GameObject;
        newPoints.transform.parent = this.transform;
        newPoints.transform.localPosition = new Vector3(-130, 60, 0);
        newPoints.transform.localScale = Vector3.one;
        pulse = true;
		Destroy (this.gameObject, 3);
    }

    void DisplayEffect() {
        grow = false;
        shrink = false;
        // Check to see if the trukey should be shrinking or growing
        if (transform.localScale.x > maxSize.x - 0.1f) {
                Debug.Log("Growing");
                targetSize = minSize;
            }
            else if (transform.localScale.x < minSize.x + 0.1f){
                Debug.Log("Shrinking");
                targetSize = maxSize;
            }
            // pulse the turkey
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, pulseSpeed * Time.deltaTime);
    }

    void Grow() {
        if (this.transform.localScale.x < 1.25f) {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.25f, 1.25f, 1.25f), pulseSpeed * Time.deltaTime);
        } else {
            grow = false;
        }
    }

    void Shrink() {
        if (this.transform.localScale.x > 1) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, pulseSpeed * Time.deltaTime);
        } else {
            shrink = false;
        }
    }

    public void Initialize(string newEmotion, int newID) {
        emotion = newEmotion;
        id = newID;
        // if (this.GetComponentInChildren<Text>()) { this.GetComponentInChildren<Text>().text = emotion; }
    }

    public void OnDrag() {
        // Debug.Log("Dragging");
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        transform.position = canvas.transform.TransformPoint(pos);
    }

    public void OnDragEnd() {
        // Debug.Log("Ending Drag");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 15);
        if (colliders.Length > 0)
        {
            // Debug.Log("Found Something");
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].tag == "Face")
                {
                    // Debug.Log("Found a Face");
                    if (colliders[i].gameObject.GetComponent<Faces>().GetID() == this.id)
                    {
                        FoundMatch(colliders, i);
                        gameController.IncreaseMatchesFound();
                    }
                }
            }
        }
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

    public void ToggleGrow() {
        grow = true;
        shrink = false;
    }

    public void ToggleShrink() {
        shrink = true;
        grow = false;
    }
}