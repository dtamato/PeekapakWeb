using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MatchGameController : MonoBehaviour {

    [Header("Sprite Lists: ")]
    [SerializeField] Sprite[] sadFaces;
    [SerializeField] Sprite[] happyFaces;
    [SerializeField] Sprite[] angryFaces;
    [SerializeField] Sprite[] surprisedFaces;
    [SerializeField] Sprite[] nervousFaces;

    [Header("UI Refernces: ")]
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject easyBoard;
    [SerializeField] GameObject medBoard;
    [SerializeField] GameObject hardBoard;

    int matchesFound = 0;
    int matchesNeeded = 0;

    GameObject firstCard;
    GameObject secondCard;

    List<GameObject> cards = new List<GameObject>();

    void Start() {
        firstCard = new GameObject();
        secondCard = new GameObject();
    }

    void ShuffleList() {
         for (int i = cards.Count - 1; i > 0; i--) {
            int rand = Random.Range(0, i);
            GameObject temp = cards[i];
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    void CreateNewCard(string newEmotion, Sprite newPicture) {
        GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newCard.GetComponent<Card>().Initialize(newEmotion, newPicture);
        cards.Add(newCard);
    }

    void PlaceCards(GameObject board) {
        foreach (GameObject card in cards) {
            card.transform.parent = board.transform;
            card.transform.localScale = Vector3.one;
            card.GetComponent<RectTransform>().localPosition = new Vector3(card.GetComponent<RectTransform>().position.x, card.GetComponent<RectTransform>().position.y, 0);
        }
    }

    void CheckCards() {
        Debug.Log("Checking Cards");
        if (firstCard.GetComponent<Card>().GetEmotion() == secondCard.GetComponent<Card>().GetEmotion()) {
            Debug.Log("Found an emotion.");
            StartCoroutine(DestroyCards());
        } else {
            Debug.Log("No match.");
            StartCoroutine(FlipCardsBack());
        }
    }

    IEnumerator DestroyCards() {
        // Do UI Stuff

        yield return new WaitForSeconds(2);
        
        for(int i = 0; i < firstCard.transform.childCount; i++) {
            if(i != 0) {
                firstCard.transform.GetChild(i).gameObject.SetActive(false);
                secondCard.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        firstCard = new GameObject();
        secondCard = new GameObject();
    }


    IEnumerator FlipCardsBack() {
        // Do UI Stuff

        yield return new WaitForSeconds(2);

        firstCard.GetComponent<Card>().ToggleCardBack();
        firstCard = new GameObject();
        secondCard.GetComponent<Card>().ToggleCardBack();
        secondCard = new GameObject();
    }

    public void StartEasyGame() {
        easyBoard.SetActive(true);
        matchesNeeded = 4;
        // Grab two cards from the first four lists
        for (int i = 0; i < 2; i++) {
            // Create Sad Cards
            CreateNewCard("sad", sadFaces[i]);
            // Create Happy Cards
            CreateNewCard("happy", happyFaces[i]);
            // Create Angry Cards
            CreateNewCard("angry", angryFaces[i]);
            // Create Surprised Cards
            CreateNewCard("surprised", surprisedFaces[i]);
        }

        ShuffleList();
        PlaceCards(easyBoard);
    }

    public void StartMediumGame() {
        matchesNeeded = 6;
        // 4 cards from the first list - 2 from the rest
    }

    public void StartHardGame() {
        matchesNeeded = 8;
        // All cards from each list
    }

    public void SelectCard(GameObject selectedCard) {
        if (!firstCard.name.Contains("Card")) {
            firstCard = selectedCard;
        } else {
            secondCard = selectedCard;
            CheckCards();
        }
    }
}
