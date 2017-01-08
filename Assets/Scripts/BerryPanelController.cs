using UnityEngine;
using System.Collections;

// Set the berry count in player prefs - berries

public class BerryPanelController : MonoBehaviour {

    [SerializeField] GameObject berryPanel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject[] berries;

    // The berry value can change in games where the player answers more than one question - 3 answers right the value is 3
    int berryValue = 0;
    int berryCount = 0;
    float speed = 10;

    void Start() {
        // PlayerPrefs.SetInt("berryCount", 0);
    }

    public void MoveBerry() {
        // Debug.Log("Calling Move Berry");
        nextButton.SetActive(false);
        berryPanel.SetActive(true);
        StartCoroutine("CallMoveBerry");
    }

    IEnumerator CallMoveBerry() {
        // Debug.Log("In Coroutine");
        berries[berryCount].GetComponent<BerryController>().MoveBerry();

        yield return new WaitForSeconds(0.15f);

        if(berryCount < 9) {
            berryCount++;
            StartCoroutine("CallMoveBerry");
        } else {
            // end the sequence
            nextButton.SetActive(true);
        }
    }

    // Increase point value when an answer is correct
    public void IncreaseScore() {
        berryValue++;
    }

    public int GetScore() {
        return berryValue;
    }
    
}
