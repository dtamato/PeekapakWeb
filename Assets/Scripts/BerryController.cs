using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BerryController : MonoBehaviour {

    BerryPanelController berryPanelController;

    [SerializeField] RectTransform berryPanel;

    bool canMove = false;
    bool updated = false;
    RectTransform rt;

    float speed = 15;

	// Use this for initialization
	void Start () {
        berryPanelController = this.transform.GetComponentInParent<BerryPanelController>();
        rt = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove && rt.localPosition.y < berryPanel.localPosition.y - 0.25f) {
            // Debug.Log("Moving");
            UpdateScore();
            rt.localPosition = Vector3.Lerp(rt.localPosition, berryPanel.localPosition, Time.deltaTime * speed);
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * speed * 0.25f);
        }
        else if (canMove && rt.localPosition.y > berryPanel.localPosition.y - 0.5f) {
            canMove = false;
            Destroy(this.gameObject);
        }
	}

    void UpdateScore() {
        if (!updated) {
            updated = true;
            int berryVal = berryPanelController.GetScore();
            int tempBerryCount = PlayerPrefs.GetInt("berryCount");
            tempBerryCount += 1;
            PlayerPrefs.SetInt("berryCount", tempBerryCount);
            berryPanel.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("berryCount").ToString();
        }
    }

    public void MoveBerry() {
        canMove = true;
    }
}
