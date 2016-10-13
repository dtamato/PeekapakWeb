using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public enum GradeLevel { PRE_K, KINDERGARTEN, GRADE1, GRADE2, GRADE3, };
    public enum Book { COURAGE, OPTIMISM, HONESTY, EMPATHY, TEAMWORK, PERSEVERANCE, KINDESS, GRATITUDE, RESPECT, SELF_REGULATION, };

    [SerializeField] Sprite[] faceSprites_perseverance;
    [SerializeField] string[] emotions_perseverance;
    // [SerializeField] Sprite[] faceSprites_teamWork;
    // [SerializeField] string[] emotions_teamWork;

    [SerializeField] Transform[] facePositions;
    [SerializeField] Transform[] emotionPositions;
    [SerializeField] GameObject facePrefab;
    [SerializeField] GameObject emotionPrefab;
    [SerializeField] GameObject canvas;
	[SerializeField] GameObject startPanel;

    List<Faces> faces = new List<Faces>();
    List<Emotions> emotions = new List<Emotions>();

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
                break;
            case Book.OPTIMISM:
                break;
            case Book.HONESTY:
                break;
            case Book.EMPATHY:
                break;
            case Book.TEAMWORK:
                break;
            case Book.PERSEVERANCE:
                SetUpGame(faceSprites_perseverance, emotions_perseverance);
                break;
            case Book.KINDESS:
                break;
            case Book.GRATITUDE:
                break;
            case Book.RESPECT:
                break;
            case Book.SELF_REGULATION:
                break;
        }
    }

    void SetUpGame(Sprite[] faceArray, string[] emotionArray) {
        // Distribute the faces and words
        FillLists(faceArray, emotionArray);
        ShuffleEmotionsList(emotions);
        ShuffleFacesList(faces);
        // Create the emotions
        for (int i = 0; i < emotions.Count; i++)
        {
            CreateEmotion(i);
        }
        // Create the faces
        for (int i = 0; i < faces.Count; i++) {
            CreateFace(i);
        }
    }

    void CreateEmotion(int i) {
        GameObject newFace = Instantiate(facePrefab, facePositions[i].position, Quaternion.identity) as GameObject;
        newFace.transform.parent = canvas.transform;
        newFace.transform.localScale = emotionPositions[i].localScale;
        newFace.GetComponent<Faces>().Initialize(faces[i].GetFace(), faces[i].GetID());
        newFace.GetComponent<Faces>().SetFaceImage();
    }

    void CreateFace(int i) {
        GameObject newEmotion = Instantiate(emotionPrefab, emotionPositions[i].position, Quaternion.identity) as GameObject;
        newEmotion.transform.parent = canvas.transform;
        newEmotion.transform.localScale = emotionPositions[i].localScale;
        newEmotion.GetComponent<Emotions>().Initialize(emotions[i].GetEmotion(), emotions[i].GetID());
        newEmotion.GetComponent<Emotions>().SetText();
    }

    void FillLists(Sprite[] faceArray, string[] emotionArray) {
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

	public void IncreaseMatchesFound(){
		matchesFound++;
		if (matchesFound >= 3) {
			// End Game
			startPanel.SetActive(true);
		}
	}

	public void SetBook(int newBook){
		currentBook = (Book)newBook;
		CheckBook ();
	}
}
