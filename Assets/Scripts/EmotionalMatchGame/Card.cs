using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    MatchGameController gameController;

    [SerializeField] Image picture;
    [SerializeField] Text emotionUI;
    [SerializeField] GameObject cardBack;

    string emotion;
    bool flipped = true;

    float growSpeed = 5;
    bool grow = false;
    bool shrink = false; 

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MatchGameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (grow) {
            ToggleGrow();
        } if (shrink) {
            ToggleShrink();
        }
	}

    public void Initialize(string newEmotion, Sprite newPicture) {
        emotion = newEmotion;
        emotionUI.text = emotion;
        picture.sprite = newPicture;
    }

    public string GetEmotion() {
        return emotion;
    }

    public void SelectCard() {
        if (cardBack.activeSelf) {
            cardBack.SetActive(false);
            gameController.SelectCard(this.gameObject);
        }
    }

    public void OnPointerEnter() {
        grow = true;
        shrink = false;
    }

    public void OnPointerExit() {
        shrink = true;
        grow = false;
    }

    void ToggleGrow() {
        if (this.transform.localScale.x < 1.25f) {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), growSpeed * Time.deltaTime);
        } else {
            grow = false;
        }
    }

    void ToggleShrink() {
        if (this.transform.localScale.x > 1) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, growSpeed * Time.deltaTime);
        } else {
            shrink = false;
        }
    }

    public void ToggleCardBack() {
        cardBack.SetActive(true);
    }
}
