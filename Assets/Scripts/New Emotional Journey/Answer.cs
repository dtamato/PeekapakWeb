using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Answer : MonoBehaviour {

    EmotionalJourneyGameController gameController;

    [SerializeField] Vector3 maxSize;
    [SerializeField] Vector3 minSize;
    [SerializeField] Text answerTextUI; 

    // Feedback Variables
    bool grow = false;
    bool shrink = false;
    bool rightAnswer = false;
    float speed = 5;
    
    string answerText;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EmotionalJourneyGameController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (grow) {
            ToggleGrow();
        } if (shrink) {
            ToggleShrink();
        }
	}

     void ToggleGrow() {
        if (this.transform.localScale.y < 1.25f) {
            transform.localScale = Vector3.Lerp(transform.localScale, maxSize, speed * Time.deltaTime);
        } else {
            grow = false;
        }
    }

    void ToggleShrink() {
        if (this.transform.localScale.y > 1) {
            transform.localScale = Vector3.Lerp(transform.localScale, minSize, speed * Time.deltaTime);
        } else {
            shrink = false;
        }
    }

    public void Initialize(string newString) {
        answerText = newString;
    }

    public void SetText() {
        answerTextUI.text = answerText;
    }
    

    public void OnPointerEnter() {
        grow = true;
        shrink = false;
    }

    public void OnPointerExit() {
        shrink = true;
        grow = false;
    }

    public void OnPointerDown() {
        SelectAnswer();
    }

    public string GetAnswer() {
        return answerText;
    }

    public void SelectAnswer() {
        gameController.CheckAnswer(rightAnswer);
    }

    public void SetRightAnswer(bool rightAnswerState) {
        rightAnswer = rightAnswerState;
    }

    public bool IsRightAnswer() {
        return rightAnswer;
    }
}
