using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public enum GradeLevel { PRE_K, KINDERGARTEN, GRADE1, GRADE2, GRADE3, };
    public enum Book { COURAGE, OPTIMISM, HONESTY, EMPATHY, TEAMWORK, PERSEVERANCE, KINDESS, GRATITUDE, RESPECT, SELF_REGULATION, };

    [Header("Courage: ")]
    [SerializeField] Sprite[] faceSprites_courage;
    [SerializeField] string[] emotions_courage;
    [SerializeField] string[] reason_courage;

    [Header("Optimism: ")]
    [SerializeField] Sprite[] faceSprites_optimism;
    [SerializeField] string[] emotions_optimism;
    [SerializeField] string[] reason_optimism;

    [Header("Honesty: ")]
    [SerializeField] Sprite[] faceSprites_honesty;
    [SerializeField] string[] emotions_honesty;
    [SerializeField] string[] reason_honesty;

    [Header("Empathy: ")]
    [SerializeField] Sprite[] faceSprites_empathy;
    [SerializeField] string[] emotions_empathy;
    [SerializeField] string[] reason_empathy;

    [Header("Kindness: ")]
    [SerializeField] Sprite[] faceSprites_kindness;
    [SerializeField] string[] emotions_kindness;
    [SerializeField] string[] reason_kindness;

    [Header("Gratitude: ")]
    [SerializeField] Sprite[] faceSprites_gratitude;
    [SerializeField] string[] emotions_gratitude;
    [SerializeField] string[] reason_gratitude;

    [Header("Respect: ")]
    [SerializeField] Sprite[] faceSprites_respect;
    [SerializeField] string[] emotions_respect;
    [SerializeField] string[] reason_respect;

    [Header("Self Regulation: ")]
    [SerializeField] Sprite[] faceSprites_selfRegulation;
    [SerializeField] string[] emotions_selfRegulation;
    [SerializeField] string[] reason_selfRegulation;

    [Header("Perseverence: ")]
    [SerializeField] Sprite[] faceSprites_perseverance;
    [SerializeField] string[] emotions_perseverance;
    [SerializeField] string[] reason_perseverence;

    [Header("Team Work: ")]
    [SerializeField] Sprite[] faceSprites_teamWork;
    [SerializeField] string[] emotions_teamWork;
    [SerializeField] string[] reason_teamWork;

    [Header("Canvas References: ")]
    [SerializeField] Transform[] facePositions;
    [SerializeField] Transform[] emotionPositions;
    [SerializeField] Transform[] reasonPositions;
    [SerializeField] GameObject facePrefab;
    [SerializeField] GameObject emotionPrefab;
    [SerializeField] GameObject reasonPrefab;
    [SerializeField] GameObject canvas;
	[SerializeField] GameObject startPanel;

    List<Faces> faces = new List<Faces>();
    List<Emotions> emotions = new List<Emotions>();
    List<Reasons> reasons = new List<Reasons>();

    Book currentBook = Book.PERSEVERANCE;
    GradeLevel currentGradeLevel = GradeLevel.PRE_K;

	int matchesFound = 0;

	// Use this for initialization
	void Start () {
        // CheckBook();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CheckBook() {
        switch (currentBook) {
            case Book.COURAGE:
                SetUpGame(faceSprites_courage, emotions_courage, reason_courage);
                break;
            case Book.OPTIMISM:
                SetUpGame(faceSprites_optimism, emotions_optimism, reason_optimism);
                break;
            case Book.HONESTY:
                SetUpGame(faceSprites_honesty, emotions_honesty, reason_honesty);
                break;
            case Book.EMPATHY:
                SetUpGame(faceSprites_empathy, emotions_empathy, reason_empathy);
                break;
            case Book.TEAMWORK:
                SetUpGame(faceSprites_teamWork, emotions_teamWork, reason_teamWork);
                break;
            case Book.PERSEVERANCE:
                SetUpGame(faceSprites_perseverance, emotions_perseverance, reason_perseverence);
                break;
            case Book.KINDESS:
                SetUpGame(faceSprites_kindness, emotions_kindness, reason_kindness);
                break;
            case Book.GRATITUDE:
                SetUpGame(faceSprites_gratitude, emotions_gratitude, reason_gratitude);
                break;
            case Book.RESPECT:
                SetUpGame(faceSprites_respect, emotions_respect, reason_respect);
                break;
            case Book.SELF_REGULATION:
                SetUpGame(faceSprites_selfRegulation, emotions_selfRegulation, reason_selfRegulation);
                break;
        }
    }

    void SetUpGame(Sprite[] faceArray, string[] emotionArray, string[] reasonArray) {
        // Distribute the faces and words
        FillLists(faceArray, emotionArray, reasonArray);
        ShuffleEmotionsList(emotions);
        ShuffleFacesList(faces);
        ShuffleReasonsList(reasons);
		// Create the faces
		for (int i = 0; i < faces.Count; i++) {
			CreateFace(i);
		}
        // Create the emotions
        for (int i = 0; i < emotions.Count; i++){
            CreateEmotion(i);
        }
        // Create the reasons
        for (int i = 0; i < reasonArray.Length; i++) {
            CreateReason(i);
        }
    }

    void CreateFace(int i) {
		Debug.Log ("Face Indexer: " + i);
        GameObject newFace = Instantiate(facePrefab, facePositions[i].position, Quaternion.identity) as GameObject;
        newFace.transform.parent = canvas.transform;
        newFace.transform.localScale = emotionPositions[i].localScale;
        newFace.GetComponent<Faces>().Initialize(faces[i].GetFace(), faces[i].GetID());
        newFace.GetComponent<Faces>().SetFaceImage();
    }

    void CreateEmotion(int i) {
        GameObject newEmotion = Instantiate(emotionPrefab, emotionPositions[i].position, Quaternion.identity) as GameObject;
        newEmotion.transform.parent = canvas.transform;
        newEmotion.transform.localScale = emotionPositions[i].localScale;
        newEmotion.GetComponent<Emotions>().Initialize(emotions[i].GetEmotion(), emotions[i].GetID());
        newEmotion.GetComponent<Emotions>().SetText();
    }

    void CreateReason(int i) {
        GameObject newReason = Instantiate(reasonPrefab, reasonPositions[i].position, Quaternion.identity) as GameObject;
        newReason.transform.parent = canvas.transform;
        newReason.transform.localScale = emotionPositions[i].localScale;
        newReason.GetComponent<Reasons>().Initialize(reasons[i].GetReason(), reasons[i].GetID());
        newReason.GetComponent<Reasons>().SetText();
    }

    void FillLists(Sprite[] faceArray, string[] emotionArray, string[]reasonArray) {
        // Fill the faces list
        for (int i = 0; i < faceArray.Length; i++) {
            Faces newFace = new Faces();
            newFace.Initialize(faceArray[i], i);
            faces.Add(newFace);
        }
        // Fill the emotions List
        for (int i = 0; i < emotionArray.Length; i++) {
            Emotions newEmotion = new Emotions();
            newEmotion.Initialize(emotionArray[i], i);
            emotions.Add(newEmotion);
        }
        // Fill the reasons List
        for (int i = 0; i < reasonArray.Length; i++) {
            Reasons newReason = new Reasons();
            newReason.Initialize(reasonArray[i], i);
            reasons.Add(newReason);
        }

    }

    void ShuffleFacesList(List<Faces> faceList) {
        for (int i = faceList.Count - 1; i > 0; i--) {
            int rand = Random.Range(0, i);
            Faces temp = faceList[i];
            faceList[i] = faceList[rand];
            faceList[rand] = temp;
        }
    }

    void ShuffleEmotionsList(List<Emotions> emotionList) {
        for (int i = emotionList.Count - 1; i > 0; i--) {
            int rand = Random.Range(0, i);
            Emotions temp = emotionList[i];
            emotionList[i] = emotionList[rand];
            emotionList[rand] = temp;
        }
    }

    void ShuffleReasonsList(List<Reasons> reasonList) {
        for (int i = reasonList.Count - 1; i > 0; i--) {
            int rand = Random.Range(0, i);
            Reasons temp = reasonList[i];
            reasonList[i] = reasonList[rand];
            reasonList[rand] = temp;
        }
    }

	IEnumerator ResetGame(){
        yield return new WaitForSeconds(3);

        startPanel.SetActive(true);

        Debug.Log("Resetting Game");
		faces = new List<Faces>();
		emotions = new List<Emotions> ();
		GameObject[] foundEmotions = GameObject.FindGameObjectsWithTag ("Emotion");
		foreach (GameObject emos in foundEmotions) {
			Destroy (emos.gameObject);
		}
		GameObject[] foundFaces = GameObject.FindGameObjectsWithTag ("Face");
		foreach (GameObject face in foundFaces) {
			Destroy (face.gameObject);
		}
		GameObject[] points = GameObject.FindGameObjectsWithTag ("Points");
		foreach (GameObject point in points) {
			Destroy (point.gameObject);
		}
        GameObject[] reasons = GameObject.FindGameObjectsWithTag("Reasons");
        foreach (GameObject reason in reasons) {
            Destroy(reason.gameObject);
        }
    }

	public void IncreaseMatchesFound(){
		matchesFound++;
		if (matchesFound == 6) {
            // End Game
            Debug.Log("Resetting Game.");
			matchesFound = 0;
			StartCoroutine(ResetGame ());
		}
	}

	public void SetBook(int newBook){
		currentBook = (Book)newBook;
		CheckBook ();
	}

    public void DisplayPointsUI() {

    }
}
