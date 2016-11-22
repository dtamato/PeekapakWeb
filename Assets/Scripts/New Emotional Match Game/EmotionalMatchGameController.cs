using UnityEngine;
using System.Collections;

public class EmotionalMatchGameController : MonoBehaviour {

    public enum Location { LUCIAS_HOUSE, TREE, SCHOOL };
    Location currentLocation;

    EmotionalMatchUIController uiController;

    [Header("Lucia's House")]
    [SerializeField] Sprite luciasHouse_panelImage;
    [SerializeField] string luciasHouse_scenario;
    [SerializeField] string[] luciasHouse_answers;

    Sprite panelImage;
    string scenario;
    int[] answers = {1, 0, 0};
    string[] answersText = new string[3];
    Sprite[] answersImages = new Sprite[3];

	// Use this for initialization
	void Start () {
        currentLocation = Location.LUCIAS_HOUSE;
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<EmotionalMatchUIController>();
        CheckLocation();
    }
	
    

	// Update is called once per frame
	void Update () {
	
	}

    void CheckLocation() {
        switch (currentLocation) {
            case Location.LUCIAS_HOUSE:
                LoadWordGame(luciasHouse_answers, luciasHouse_panelImage, luciasHouse_scenario);
                break;
            case Location.SCHOOL:
                break;
            case Location.TREE:
                break;
        }
    }

    void LoadWordGame(string[] newAnswersText, Sprite newPanelImage, string newScenario) {
        // Fill the current game variables
        scenario = newScenario;
        panelImage = newPanelImage;
        for (int i = 0; i < newAnswersText.Length; i++) {
            answersText[i] = newAnswersText[i];
        }

        // Shuffle the right answers and their corresponding 
        ShuffleTextAnswers();
        // Send those results to the UI Controller so it can apply the tags

    }

    void LoadTextGame(Sprite[] newAnswersImages, Sprite newPanelImage, string newScenario) {
        // Fill the current game variables
        scenario = newScenario;
        panelImage = newPanelImage;
        for (int i = 0; i < newAnswersImages.Length; i++) {
            answersImages[i] = newAnswersImages[i];
        }
        // Shuffle the right answers and their corresponding 
        ShuffleImageAnswers();
        // Send those results to the UI Controller so it can apply the tags

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
            int tempInt = answers[i];
            // Get a random value
            int rand = Random.Range(0, answers.Length);
            // Set the new text values
            answers[i] = answers[rand];
            answers[rand] = tempInt;
            // Set the new int values
            answersImages[i] = answersImages[rand];
            answersImages[rand] = tempImage;
        }
    }

    public void CheckAnswer(GameObject answer) {
        if (answer.CompareTag("Right Answer")) {

        } else if (answer.CompareTag("Wrong Answer")) {

        }
    }
}
