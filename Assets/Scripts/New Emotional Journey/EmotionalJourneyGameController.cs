using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionalJourneyGameController : MonoBehaviour {

    public enum GameStage { STAGE_1, STAGE_2 };
    GameStage currentStage;
    
    [Header("Text References: ")]
    [SerializeField] string[] selfRegulation_Dialogue;
    [SerializeField] string[] selfRegulation_Questions;
    [SerializeField] string[] selfRegulation_Options;
    [SerializeField] int[] selfRegulation_RightAnswers;

    [Header("UI Refernces: ")]
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject gameBoard;
    [SerializeField] Text dialogueTextUI;
    [SerializeField] Text questionUI;
    [SerializeField] Text[] answerUI;

    string currentBook;
    string[] dialogue;
    string[] questions;
    string[] answers;
    int[] rightAnswers;
    bool canClick = false;
    int stageCounter = 0;
    int answerCounter = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && canClick) {
            // CheckStage();
            ShowGameboard(false);
        }
	}

    void CheckStage() {
        switch (currentStage) {
            case GameStage.STAGE_1:
                ShowGameboard(false);
                break;
            case GameStage.STAGE_2:
                break;
        }
    }

    void CheckBook (){
        if (currentBook == "SR") {
            Debug.Log("Filling Book");

            dialogue = new string[selfRegulation_Dialogue.Length];
            answers = new string[selfRegulation_Options.Length];
            questions = new string[selfRegulation_Questions.Length];
            rightAnswers = new int[selfRegulation_RightAnswers.Length];

            for (int i = 0; i < selfRegulation_Dialogue.Length; i++) {
                dialogue[i] = selfRegulation_Dialogue[i];
            }
            
            for(int i = 0; i < selfRegulation_Options.Length; i++) {
                answers[i] = selfRegulation_Options[i];
            }

            for(int i = 0; i < selfRegulation_Questions.Length; i++) {
                questions[i] = selfRegulation_Questions[i];
            }

            for(int i = 0; i < selfRegulation_RightAnswers.Length; i++) {
                rightAnswers[i] = selfRegulation_RightAnswers[i];
            }
        }
    }

    void ShowGameboard(bool redo) {
        canClick = false;
        gameBoard.SetActive(true);
        questionUI.text = questions[(int)(currentStage)];
        dialogueUI.SetActive(false);

        for (int i = 0; i < 3; i++) {
            answerUI[i].text = answers[answerCounter];
            if (redo == false) { answerCounter++; }
        }
    }

    IEnumerator ToggleCanClick() {
        yield return new WaitForSeconds(1);
        canClick = true;
    }

    public void CheckAnswer() {

    }

    public void RightAnswer() {
        stageCounter++;
    }

    public void WrongAnswer() {
        ShowGameboard(true);
    }

    public void StartGame(string book) {
        currentStage = GameStage.STAGE_1;
        currentBook = book;
        CheckBook();
        dialogueUI.SetActive(true);
        Debug.Log("dialogue" + dialogue[0]);
        dialogueTextUI.text = dialogue[0];
        StartCoroutine(ToggleCanClick());
    }
}
