using UnityEngine;
using System.Collections;

public class EmotionalMatchAnswer : MonoBehaviour {

    bool rightAnswer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetRightAnswer(bool answer) {
        rightAnswer = answer;
    }

    bool RightAnswer() {
        return rightAnswer;
    }
}
