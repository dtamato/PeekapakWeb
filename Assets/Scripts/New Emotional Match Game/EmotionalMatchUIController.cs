using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionalMatchUIController : MonoBehaviour {

    [SerializeField] GameObject rightAnswerPanel;
    [SerializeField] GameObject wrongAnswerPanel;
    [SerializeField] GameObject gameBoard;

    [SerializeField] Text[] answers;
    [SerializeField] Image panelImage;
    [SerializeField] Text scenarioText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadWordGame(string[] newAnswers, int[] answerValues, Sprite naePanelImage, Text newScenario) {

    }

    public void LoadImageGame(Sprite[] newAnswers, int[] answerValues, Sprite naePanelImage, Text newScenario) {

    }

    public void RightAAnswer() {
        // gameBoard.SetActive(false);
        rightAnswerPanel.SetActive(true);
    }

    public void WrongAnswer() {
        // gameBoard.SetActive(false);
        wrongAnswerPanel.SetActive(true);
    }

    public void TryAgain() {
        if (wrongAnswerPanel.activeSelf) {
            wrongAnswerPanel.SetActive(false);
        } else if (rightAnswerPanel.activeSelf) {
            rightAnswerPanel.SetActive(false);
        }
    }
}
