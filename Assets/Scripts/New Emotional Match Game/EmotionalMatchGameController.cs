using UnityEngine;
using System.Collections;

public class EmotionalMatchGameController : MonoBehaviour {

    public enum Location { LUCIAS_HOUSE, TREE, SCHOOL };
    Location currentLocation;

    EmotionalMatchUIController uiController;

    [Header("Lucia's House")]
    [SerializeField] Sprite luciasHouse_panelImage;
    [SerializeField] string luciasHouse_scenario;
    [SerializeField] string luciasHouse_rightAnswerResponse;
    [SerializeField] string luciasHouse_wrongAnswerResponse;
    [SerializeField] Sprite[] luciasHouse_answersImages;
    [SerializeField] string[] luciasHouse_answersText;

    [Header("School")]
    [SerializeField] Sprite school_panelImage;
    [SerializeField] string school_scenario;
    [SerializeField] string school_rightAnswerResponse;
    [SerializeField] string school_wrongAnswerResponse;
    [SerializeField] string[] school_answersText;

    [Header("Lucia's House")]
    [SerializeField] Sprite tree_panelImage;
    [SerializeField] string tree_scenario;
    [SerializeField] string tree_rightAnswerResponse;
    [SerializeField] string tree_wrongAnswerResponse;
    [SerializeField] Sprite[] tree_answersImages;
    [SerializeField] string[] tree_answersText;

    Sprite panelImage;
    string scenario;
    string rightAnswerResponse;
    string wrongAnswerResponse;
    int[] answers = {1, 0, 0};
    string[] answersText = new string[3];
    Sprite[] answersImages = new Sprite[3];

	// Use this for initialization
	void Start () {
        FindLocation();
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<EmotionalMatchUIController>();
        CheckLocation();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FindLocation() {
        Debug.Log("Finidng Location: " + PlayerPrefs.GetString("Location"));
        // Check the location and load the appropriate games
        if (PlayerPrefs.GetString("Location") != null) {
            if (PlayerPrefs.GetString("Location") == "Lucia's House") {
                currentLocation = Location.LUCIAS_HOUSE;
            } else if (PlayerPrefs.GetString("Location") == "School") {
                currentLocation = Location.SCHOOL;
            } else if (PlayerPrefs.GetString("Location") == "Tree") {
                currentLocation = Location.TREE;
            }
        } else { 
            currentLocation = Location.TREE;
        }
    }

    void CheckLocation() {
        switch (currentLocation) {
            case Location.LUCIAS_HOUSE:
                LoadGame(luciasHouse_panelImage, luciasHouse_scenario, luciasHouse_rightAnswerResponse, luciasHouse_wrongAnswerResponse);
                LoadImageGame(luciasHouse_answersImages, luciasHouse_answersText);
                break;
            case Location.SCHOOL:
                LoadGame(school_panelImage, school_scenario, school_rightAnswerResponse, school_wrongAnswerResponse);
                LoadWordGame(school_answersText);
                break;
            case Location.TREE:
                LoadGame(tree_panelImage, tree_scenario, tree_rightAnswerResponse, tree_wrongAnswerResponse);
                LoadImageGame(tree_answersImages, tree_answersText);
                break;
        }
    }

    void LoadGame(Sprite newPanelImage, string newScenario, string newRightAnswer, string newWrongAnswer) {
        scenario = newScenario;
        panelImage = newPanelImage;
        rightAnswerResponse = newRightAnswer;
        wrongAnswerResponse = newWrongAnswer;
    }

    void LoadWordGame(string[] newAnswersText) {
        for (int i = 0; i < newAnswersText.Length; i++) {
            answersText[i] = newAnswersText[i];
        }

        // Shuffle the right answers and their corresponding 
        ShuffleTextAnswers();
        // Send those results to the UI Controller so it can apply the tags
        uiController.LoadWordGame(answersText, answers, panelImage, scenario, rightAnswerResponse, wrongAnswerResponse);
    }

    void LoadImageGame(Sprite[] newAnswersImages, string[] newAnswersText) {
        for (int i = 0; i < newAnswersImages.Length; i++) {
            answersImages[i] = newAnswersImages[i];
            answersText[i] = newAnswersText[i];
        }
        // Shuffle the right answers and their corresponding 
        ShuffleImageAnswers();
        // Send those results to the UI Controller so it can apply the tags
        uiController.LoadImageGame(answersImages, answersText, answers, panelImage, scenario, rightAnswerResponse, wrongAnswerResponse);
    }

    void ShuffleTextAnswers() {
        for (int i = 0; i < answers.Length; i++) {
            string tempText = answersText[i];
            int tempInt = answers[i];
            // Get a random Value
            int rand = Random.Range(0, answers.Length);
            // Set the new text values
            answers[i] = answers[rand];
            answers[rand] = tempInt;
            // Set the new int values
            answersText[i] = answersText[rand];
            answersText[rand] = tempText;
        }
    }

    void ShuffleImageAnswers() {
        for (int i = 0; i < answers.Length; i++) {
            Sprite tempImage = answersImages[i];
            string tempString = answersText[i];
            int tempInt = answers[i];
            // Get a random value
            int rand = Random.Range(0, answers.Length);
            // Set the new text values
            answers[i] = answers[rand];
            answers[rand] = tempInt;
            // Set the new int values
            answersImages[i] = answersImages[rand];
            answersImages[rand] = tempImage;
            // Set the new String Values
            answersText[i] = answersText[rand];
            answersText[rand] = tempString;
        }
    }

    public void CheckAnswer(GameObject answer) {
        Debug.Log("Checking Answer");

        if (answer.CompareTag("Right Answer")) {
            Debug.Log("right Answer");
            uiController.RightAnswer();

        } else if (answer.CompareTag("Wrong Answer")) {
            Debug.Log("wrong Answer");
            uiController.WrongAnswer();
        }
    }
}
