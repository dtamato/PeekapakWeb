using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmotionalJourneyGameController : MonoBehaviour {
    
    [SerializeField] GameObject answerPrefab;

    [Header("Text References: ")]
    [SerializeField] string[] selfRegulation_Dialogue;
    [SerializeField] string[] selfRegulation_Questions;
    [SerializeField] string[] selfRegulation_Options;

    [Header("UI Refernces: ")]
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject gameBoard;
    [SerializeField] GameObject character;
    [SerializeField] Text dialogueTextUI;
    [SerializeField] Text questionUI;
    [SerializeField] Transform[] answersUI;
    [SerializeField] GameObject berryPanel;

    string currentBook;
    string[] dialogue;
    string[] questions;
    string[] answers;
    string[] currentAnswers;
    int[] rightAnswers;
    bool gameStarted = false;
    public bool shuffled = false;

    public int stage;

	// Use this for initialization
	void Start () {
        // Debug.Log("Starting Game");
        PlayerPrefs.SetInt("berryCount", 0);
	}
	
    // Check which book/location the game is in a load the arrays accordingly
    void CheckBook (){
        if (currentBook == "SR") {
            Debug.Log("Filling Book");

            dialogue = new string[selfRegulation_Dialogue.Length];
            questions = new string[selfRegulation_Questions.Length];
            answers = new string[selfRegulation_Options.Length];
            rightAnswers = new int[3];

            for (int i = 0; i < selfRegulation_Dialogue.Length; i++) {
                dialogue[i] = selfRegulation_Dialogue[i];
            }
            
            for(int i = 0; i < selfRegulation_Options.Length; i++) {
                answers[i] = selfRegulation_Options[i];
            }

            for(int i = 0; i < selfRegulation_Questions.Length; i++) {
                questions[i] = selfRegulation_Questions[i];
            }

            // The first answer before they are suffled is the right answer
            for (int i = 0; i < 3; i++) {
                if (i == 0) { rightAnswers[i] = 1; }
                else { rightAnswers[i] = 0; }
            }
        }
    }

    public void ShowGameboard() {
        // Debug.Log("Show Gameboard");

        if (stage == 2) {
            EndGame();
            OpenEndPanel();
        } else {
            InitializeBoard();
        }
    }

    void InitializeBoard() {
        // Toggle on and off the panles accordingly
        gameBoard.SetActive(true);
        questionUI.text = questions[stage];
        dialogueUI.SetActive(false);

        // Set i according to what stage we are on
        int i = 0;
        if (stage == 0) { i = 0; }
        else if (stage == 1) { i = 3; }
        int target = i + 3;
        
        if (!shuffled) {
            // Initialize the Answers
            InitializeAnswers(i, target);
            // Shuffle Current Answers
            ShuffleAnswers();
            // Place Current Answers
            PlaceAnswers();
        }
    }

    void InitializeAnswers(int i, int target) {
        // Clear the current answers array
        currentAnswers = new string[3];

        for (int j = 0; j < 3; j++) {
            // get rid of the current answer 
            Destroy(answersUI[j].GetChild(0).gameObject);
        }

        for (int j = 0; j < 3; j++) {
            if (j == 0) { rightAnswers[j] = 1; }
            else { rightAnswers[j] = 0; }
        }

        // Fill the current answers array
        int counter = 0;
        for (; i < target; i++)  {
            Debug.Log("Filling Array");
            currentAnswers[counter] = answers[i];
            counter++;
        }
    }

    void ShuffleAnswers() {
        shuffled = true;
        Debug.Log("Shuffling");
        for (int i = 0; i < currentAnswers.Length; i++) {
            // Set a temp holder for the index you are swapping
            string tempAnswer = currentAnswers[i];
            int tempInt = rightAnswers[i];
            // Get a random Value
            int rand = Random.Range(0, currentAnswers.Length - 1);
            // Set the new random answer
            currentAnswers[i] = currentAnswers[rand];
            rightAnswers[i] = rightAnswers[rand];
            // Set the random slot to your temp data
            currentAnswers[rand] = tempAnswer;
            rightAnswers[rand] = tempInt;
        }
    }

    void PlaceAnswers() {
        for (int i = 0; i < 3; i++) {
            // Create a new Answer
            GameObject newAnswer = Instantiate(answerPrefab, answersUI[i].localPosition, answersUI[i].localRotation) as GameObject;
            newAnswer.GetComponent<Answer>().Initialize(currentAnswers[i]);
            newAnswer.transform.SetParent(answersUI[i]);
            newAnswer.transform.localPosition = Vector3.zero;
            newAnswer.transform.localScale = Vector3.one;
            newAnswer.GetComponent<Answer>().SetText();
            if (rightAnswers[i] == 1) { newAnswer.GetComponent<Answer>().SetRightAnswer(true); }
        }
    }

    void ShowAnswerResult(bool right) {
        // Turn off the Game board 
        gameBoard.SetActive(false);
        // Turn on the dilaogue box
        dialogueUI.SetActive(true);
        NextQuestion();
    }

    void NextQuestion() {
        // Debug.Log("Next Question please!");
        shuffled = false;
        if (stage == 1) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[2].Replace("___", "\n"); }
        else if (stage == 2) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[4].Replace("___", "\n"); }
        character.GetComponent<Character>().ChangeImage(stage);
    }

    public void OpenEndPanel() {
        berryPanel.SetActive(true);
        // berryPanel.GetComponentInChildren<BerryPanelController>().MoveBerry();
        berryPanel.GetComponent<AnswerPanelController>().ToggleMoveIn(true);
    }

    public void EndGame() {
        dialogueUI.SetActive(false);

        // Allow player to playe again
        // character.GetComponent<Character>().SetTapped(false);

        // Reset all booleans 
        gameStarted = false;
        // Reset Stage
        stage = 0;
        // character.GetComponent<Character>().ChangeImage(stage);
    }

    public void CheckAnswer(bool rightAnswer) {
        // Debug.Log("Checking Answer");
        if (rightAnswer) {
            RightAnswer();
        } else {
            WrongAnswer();
        }
    }

    public void RightAnswer() {
        stage++;
        ShowAnswerResult(true);
    }

    void WrongAnswer() {
        // Turn off the Game board 
        gameBoard.SetActive(false);
        // Turn on the dilaogue box
        dialogueUI.SetActive(true);
        if (stage == 0) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[1]; }
        else if (stage == 1) { dialogueUI.GetComponentInChildren<Text>().text = dialogue[3]; }
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
        }
    }

    public bool GameStarted() {
        return gameStarted;
    }
}
