using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionalJourneyGameController : MonoBehaviour {

    public enum GameStage { STAGE_1, STAGE_2 };
    GameStage currentStage;

    [SerializeField] GameObject answerPrefab;

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
    [SerializeField] Transform[] answersUI;

    string currentBook;
    string[] dialogue;
    string[] questions;
    Answer[] answers;
    int[] rightAnswers;
    bool canClick = false;
    bool gameStarted = false;
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
            answers = new Answer[selfRegulation_Options.Length];
            questions = new string[selfRegulation_Questions.Length];
            rightAnswers = new int[selfRegulation_RightAnswers.Length];

            for (int i = 0; i < selfRegulation_Dialogue.Length; i++) {
                dialogue[i] = selfRegulation_Dialogue[i];
            }
            
            for(int i = 0; i < selfRegulation_Options.Length; i++) {
                answers[i] = new Answer();
                answers[i].Initialize(i, selfRegulation_Options[i]);
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
            // answerUI[i].text = answers[answerCounter];
            GameObject newAnswer = Instantiate(answerPrefab, answersUI[i].localPosition, answersUI[i].localRotation) as GameObject;
            newAnswer.GetComponent<Answer>().Initialize(answers[answerCounter].GetIndex(), answers[answerCounter].GetAnswer());
            newAnswer.transform.parent = answersUI[i];
            newAnswer.transform.localPosition = Vector3.zero;
            newAnswer.transform.localScale = Vector3.one;
            newAnswer.GetComponent<Answer>().SetText();
            if (redo == false) { answerCounter++; }
        }
    }

    void ShowAnswerResult() {

    }

    IEnumerator ToggleCanClick() {
        yield return new WaitForSeconds(1);
        canClick = true;
    }

    public void CheckAnswer(int answerIndex) {
        if(currentStage == GameStage.STAGE_1) {
            if (answerIndex == rightAnswers[(int)currentStage]) {
                RightAnswer(answerIndex);
            } else {
                WrongAnswer(answerIndex);
            }
        }
    }

    public void RightAnswer(int answerIndex) {
        stageCounter++;
        ShowAnswerResult();
    }

    public void WrongAnswer(int answerIndex) {
        //ShowGameboard(true);
        ShowAnswerResult();
    }

    public void StartGame(string book) {
        gameStarted = true;
        currentStage = GameStage.STAGE_1;
        currentBook = book;
        CheckBook();
        dialogueUI.SetActive(true);
        Debug.Log("dialogue" + dialogue[0]);
        dialogueTextUI.text = dialogue[0];
        StartCoroutine(ToggleCanClick());
    }

    public bool GameStarted() {
        return gameStarted;
    }
}
