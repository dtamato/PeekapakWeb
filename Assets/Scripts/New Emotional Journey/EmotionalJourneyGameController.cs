using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmotionalJourneyGameController : MonoBehaviour {
    
    [SerializeField] GameObject answerPrefab;

    [Header("Text References: ")]
    [Header("Leo's Home: ")]
    [SerializeField] string[] leosHome_Dialogue;
    [SerializeField] string[] leosHome_Questions;
    [SerializeField] string[] leosHome_Options;
    [SerializeField] string leosHome_infoBit;

    [Header("Library:")]
    [SerializeField] string[] library_Dialogue;
    [SerializeField] string[] library_Questions;
    [SerializeField] string[] library_Options;
    [SerializeField] string library_infoBit;

    [Header("School Hallway: ")]
    [SerializeField] string[] schoolHall_Dialogue;
    [SerializeField] string[] schoolHall_Questions;
    [SerializeField] string[] schoolHall_Options;
    [SerializeField] string schoolHall_infoBit;

    [Header("Tree Of Gratitude: ")]
    [SerializeField] string[] TOG_Dialogue;
    [SerializeField] string[] TOG_Questions;
    [SerializeField] string[] TOG_Options;
    [SerializeField] string TOG_infoBit;

    [Header("Classroom: ")]

    [Header("Image References: ")]
    [Header("Leo's Home: ")]
    [SerializeField] Sprite leosHome_BG;
    [SerializeField] Sprite leosHome_CharacterGlow;
    [SerializeField] Sprite[] leosHome_Character;

    [Header("Library:")]
    [SerializeField] Sprite library_BG;
    [SerializeField] Sprite library_CharacterGlow;
    [SerializeField] Sprite[] library_Character;

    [Header("School Hallway: ")]
    [SerializeField] Sprite schoolHall_BG;
    [SerializeField] Sprite schoolHall_CharacterGlow;
    [SerializeField] Sprite[] schoolHall_Character;

    [Header("Tree Of Gratitude: ")]
    [SerializeField] Sprite TOG_BG;
    [SerializeField] Sprite TOG_CharacterGlow;
    [SerializeField] Sprite[] TOG_Character;

    [Header("Classroom: ")]

    [Header("UI Refernces: ")]
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject gameBoard;
    [SerializeField] GameObject character;
    [SerializeField] Text dialogueTextUI;
    [SerializeField] Text questionUI;
    [SerializeField] Text infoBitUI;
    [SerializeField] Transform[] answersUI;
    [SerializeField] GameObject berryPanel;
    [SerializeField] Image background;

    [Header("Infobit Locations(this will take a while)")]
    [SerializeField] Vector3[] infoBitLocations;

    // Variables and Arrays being send and used by the game
    string currentBook = "TOG";
    string defaultInfoBit = "such information, much knowledge, very insight";
    string[] dialogue;
    string[] questions;
    string[] answers;
    string[] currentAnswers;
    int[] rightAnswers;
    Sprite bg;

    bool gameStarted = false;
    bool shuffled = false;
    int stage;

	// Use this for initialization
	void Start () {
        CheckBook();
        PlayerPrefs.SetInt("berryCount", 0);
	}
	
    // Check which book/location the game is in a load the arrays accordingly
    void CheckBook (){
        // Current Book will check the player prefs value, currentBook, that will be set in the map scene
        if (currentBook == "Leo's Home") {
            // Filling Leo's Home
            FillArrays(leosHome_Dialogue, leosHome_Options, leosHome_Questions, leosHome_infoBit);
            SetUpScene(leosHome_BG, leosHome_CharacterGlow, leosHome_Character);            
        }
        if (currentBook == "Library") {
            FillArrays(library_Dialogue, library_Options, library_Questions, library_infoBit);
            SetUpScene(library_BG, library_CharacterGlow, library_Character);
        }
        if (currentBook == "School Hallway") {
            FillArrays(schoolHall_Dialogue, schoolHall_Options, schoolHall_Questions, schoolHall_infoBit);
            SetUpScene(schoolHall_BG, schoolHall_CharacterGlow, schoolHall_Character);
        }
        if (currentBook == "TOG") {
            FillArrays(TOG_Dialogue, TOG_Options, TOG_Questions, TOG_infoBit);
            SetUpScene(TOG_BG, TOG_CharacterGlow, TOG_Character);
        }
    }

    void SetUpScene(Sprite newBG, Sprite newCharacterGlow, Sprite[] newCharacterMoods) {
        bg = newBG;
        background.sprite = bg;
        character.GetComponent<Character>().SetImageList(newCharacterMoods, newCharacterGlow);
    }
    
    void FillArrays(string[] newDialogue, string[] newOptions, string[] newQuestions, string newInfobit) {
        dialogue = new string[newDialogue.Length];
        answers = new string[newOptions.Length];
        questions = new string[leosHome_Questions.Length];
        rightAnswers = new int[3];

        for (int i = 0; i < newDialogue.Length; i++) {
            dialogue[i] = newDialogue[i];
        }

        for (int i = 0; i < newOptions.Length; i++){
            answers[i] = newOptions[i];
        }

        for (int i = 0; i < newQuestions.Length; i++) {
            questions[i] = newQuestions[i];
        }

        // The first answer before they are suffled is the right answer
        for (int i = 0; i < 3; i++) {
            if (i == 0) { rightAnswers[i] = 1; }
            else { rightAnswers[i] = 0; }
        }

        // Set the infoBit
        infoBitUI.text = newInfobit;
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
        berryPanel.GetComponent<AnswerPanelController>().ToggleMoveIn(true);
    }

    public void EndGame() {
        dialogueUI.SetActive(false);
        
        // Reset all booleans 
        gameStarted = false;
        // Reset Stage
        stage = 0;
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

    // being called from the character - Get the current location from the player prefs later
    public void StartGame() {
        if (gameStarted == false) {
            gameStarted = true;
            stage = 0;
            character.GetComponent<Character>().ChangeImage(stage);
            // currentBook = book;
            CheckBook();
            dialogueUI.SetActive(true);
            dialogueTextUI.text = dialogue[0];
        }
    }

    public bool GameStarted() {
        return gameStarted;
    }
}
