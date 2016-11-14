using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionalJourneyGameController : MonoBehaviour {
    
    [SerializeField] GameObject answerPrefab;

    [Header("Text References: ")]
    [SerializeField] string[] selfRegulation_Dialogue;
    [SerializeField] string[] selfRegulation_Questions;
    [SerializeField] string[] selfRegulation_Options;
    [SerializeField] int[] selfRegulation_RightAnswers;

    [Header("UI Refernces: ")]
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject gameBoard;
    [SerializeField] GameObject character;
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
    bool answeredQuestion = false;
    int stage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && canClick) {
            Debug.Log("Clicking");
            ShowGameboard();
        }

        if (Input.GetMouseButtonDown(0) && answeredQuestion && stage <= 1) {
            Debug.Log("Clicking");
            ShowGameboard();
        }

        if (Input.GetMouseButtonDown(0) && answeredQuestion && stage ==  2){
            Debug.Log("End Game");
            EndGame();
        }
    }

    // Check which book/location the game is in a load the arrays accordingly
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

    void ShowGameboard() {
        Debug.Log("Show Gameboard");
        
        // Toggle on and off the panles accordingly
        gameBoard.SetActive(true);
        questionUI.text = questions[stage];
        dialogueUI.SetActive(false);

        // Set i according to what stage we are on
        int i = 0;
        if (stage == 0) { i = 0; }
        else if (stage == 1) { i = 3; }

        // If you are not responding to a question, initilaize the board
        if (!answeredQuestion) {
            // Fill and create the questions
            for (; i < 3; i++) {
                // Create a new Answer
                GameObject newAnswer = Instantiate(answerPrefab, answersUI[i].localPosition, answersUI[i].localRotation) as GameObject;
                newAnswer.GetComponent<Answer>().Initialize(answers[i].GetIndex(), answers[i].GetAnswer());
                newAnswer.transform.SetParent(answersUI[i]);
                newAnswer.transform.localPosition = Vector3.zero;
                newAnswer.transform.localScale = Vector3.one;
                newAnswer.GetComponent<Answer>().SetText();
            }
        }
        // Otherwise, just fill the questions depending on which stage we are in
        else {
            for (int j = 0; j < 3; j++) {
                // get rid of the current answer 
                Destroy(answersUI[j].GetChild(0).gameObject);
                // Reset a new one 
                GameObject newAnswer = Instantiate(answerPrefab, answersUI[j].localPosition, answersUI[j].localRotation) as GameObject;
                newAnswer.GetComponent<Answer>().Initialize(answers[i].GetIndex(), answers[i].GetAnswer());
                newAnswer.transform.SetParent(answersUI[j]);
                newAnswer.transform.localPosition = Vector3.zero;
                newAnswer.transform.localScale = Vector3.one;
                newAnswer.GetComponent<Answer>().SetText();
                i++;
            }
        }

        // Reset Booleans
        canClick = false;
        answeredQuestion = false;
    }
    
    void ShowAnswerResult(bool right) {
        // answeredQuestion = true;
        // Turn off the Game board 
        gameBoard.SetActive(false);
        // Turn on the dilaogue box
        dialogueUI.SetActive(true);
        // Allow for any-time player inut
        StartCoroutine(ToggleAnswerQuestion());
        if (right) {
            Debug.Log("Next Question please!");
            if (stage == 0) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[2]; }
            else if (stage == 1) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[4]; }
            stage++;
            character.GetComponent<Character>().ChangeImage(stage);
        } else {
            Debug.Log("WrongAnswer");
            // Present the wrong answer text depending on the stage
            if (stage == 0) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[1]; }
            else if (stage == 1) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[3]; }
        }
    }

    void EndGame() {
        dialogueUI.SetActive(false);
        // Make Leo Look Sad again??

        // Allow player to playe again
        character.GetComponent<Character>().SetTapped(false);
        // Remove all of the old answers
        foreach (Transform answer in answersUI) {
            Destroy(answer.GetChild(0).gameObject);
        }
        // Reset all booleans 
        canClick = false;
        gameStarted = false;
        answeredQuestion = false;
        // Reset Stage
        stage = 0;
        character.GetComponent<Character>().ChangeImage(stage);
    }

    IEnumerator ToggleCanClick() {
        yield return new WaitForSeconds(1);
        canClick = true;
    }

    IEnumerator ToggleAnswerQuestion()  {
        yield return new WaitForSeconds(1);
        answeredQuestion = true;
    }

    public void CheckAnswer(int answerIndex) {
        Debug.Log("Checking Answer");
        if(stage == 0) {
            if (answerIndex == rightAnswers[stage]) {
                RightAnswer(answerIndex);
            } else {
                WrongAnswer(answerIndex);
            }
        }
        else if (stage == 1) {
            if (answerIndex == rightAnswers[stage]) {
                RightAnswer(answerIndex);
            } else {
                WrongAnswer(answerIndex);
            }
        }
    }

    public void RightAnswer(int answerIndex) {
        // stage++;
        ShowAnswerResult(true);
    }

    public void WrongAnswer(int answerIndex) {
        ShowAnswerResult(false);
    }

    public void StartGame(string book) {
        if (gameStarted == false) {
            gameStarted = true;
            stage = 0;
            character.GetComponent<Character>().ChangeImage(stage);
            currentBook = book;
            CheckBook();
            dialogueUI.SetActive(true);
            dialogueTextUI.text = dialogue[0];
            StartCoroutine(ToggleCanClick());
        }
    }

    public bool GameStarted() {
        return gameStarted;
    }
}
