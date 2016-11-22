using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionalMatchUIController : MonoBehaviour {

    [SerializeField] GameObject rightAnswerPanel;
    [SerializeField] GameObject wrongAnswerPanel;
    [SerializeField] GameObject textAnswersPanel;
    [SerializeField] GameObject textAndImageAnswersPanel;
    [SerializeField] GameObject gameBoard;

    [SerializeField] Text[] textAnswers;
    [SerializeField] Image[] imageAnswers;
    [SerializeField] Text[] imageDefinitions;
    [SerializeField] Image panelImage;
    [SerializeField] Text scenarioText;
    [SerializeField] Text wrongAnswerRespose;
    [SerializeField] Text rightAnswerRespose;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadGame(Sprite newPanelImage, string newScenario, string newRightAnswer, string newWrongAnswer) {
        // Set the Panel Image
        panelImage.sprite = newPanelImage;
        // Set the Scenario Text
        scenarioText.text = newScenario;
        // Set the wrong and right answer responses
        rightAnswerRespose.text = newRightAnswer;
        wrongAnswerRespose.text = newWrongAnswer;
    }

    public void LoadWordGame(string[] newAnswers, int[] answerValues, Sprite newPanelImage, string newScenario, string newRightAnswer, string newWrongAnswer) {
        // Make sure the right answer options are toggled on
        textAnswersPanel.SetActive(true);
        textAndImageAnswersPanel.SetActive(false);
        // Fill the words
        for (int i = 0; i < newAnswers.Length; i++) {
            textAnswers[i].text = newAnswers[i];
            if (answerValues[i] == 1) { textAnswers[i].transform.parent.gameObject.tag = "Right Answer"; }
            else { textAnswers[i].transform.parent.gameObject.tag = "Wrong Answer"; }
        }

        LoadGame(newPanelImage, newScenario, newRightAnswer, newWrongAnswer);
    }

    public void LoadImageGame(Sprite[] newAnswerImages, string[] newAnswersText, int[] answerValues, Sprite newPanelImage, string newScenario, string newRightAnswer, string newWrongAnswer) {
        Debug.Log("Loading Game Visuals");
        // Make sure the right answer options are toggled on
        textAnswersPanel.SetActive(false);
        textAndImageAnswersPanel.SetActive(true);
        // Fill the Images and set them to maintain aspect ratio
        for (int i = 0; i < newAnswerImages.Length; i++) {
            imageDefinitions[i].text = newAnswersText[i];
            imageAnswers[i].sprite = newAnswerImages[i];
            imageAnswers[i].preserveAspect = true;
            // If this is the right answer
            if (answerValues[i] == 1) { imageAnswers[i].transform.parent.gameObject.tag = "Right Answer"; }
            // If it is the worng answer
            else { imageAnswers[i].transform.parent.gameObject.tag = "Wrong Answer"; }
        }

        LoadGame(newPanelImage, newScenario, newRightAnswer, newWrongAnswer);
    }

    public void RightAnswer() {
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
