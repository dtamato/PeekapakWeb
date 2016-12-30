using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class AnswerPanelController : MonoBehaviour {

    [Header("Object References")]
    [SerializeField] RectTransform panel;
    [SerializeField] Image transparentBackground;

    [Header("Attributes:")]
    [SerializeField]
    bool rightAnswer = true;

    bool moveIn = false;
    bool moveOut = false;
    bool gameOver = false;
    float opacityTarget = 0.3f;
    float moveSpeed = 10;
    Vector3 targetPosOnCam;
    Vector3 targetPosOffCam;

    // Use this for initialization
    void Start () {
        // panelRT = panel.GetComponent<RectTransform>();
        targetPosOnCam = new Vector3(-1, panel.localPosition.y, panel.localPosition.z);
        targetPosOffCam = panel.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (moveIn) { MovePanelIn(); }
        if (moveOut) { MovePanelOut(); }
	}

    public void MovePanelIn() {
        // Move the object towards the center of the screen (xPos of 0)
        if (panel.localPosition.x > 0) {
            panel.transform.localPosition = Vector3.Lerp(panel.transform.localPosition, targetPosOnCam, moveSpeed * Time.deltaTime);
            float newAlpha = Mathf.Lerp(transparentBackground.color.a, opacityTarget, moveSpeed * Time.deltaTime);
            transparentBackground.color = new Vector4(1, 1, 1, newAlpha);
        } else {
            // Stop the panel from moving
            moveIn = false;
            if (gameOver && panel.GetComponentInChildren<BerryPanelController>() != null) {
                panel.GetComponentInChildren<BerryPanelController>().MoveBerry();
            }
        }
    }

    public void MovePanelOut() {
        Debug.Log("Moving Panel Out");
        if (panel.localPosition.x < targetPosOffCam.x - 0.5f) {
            Debug.Log("Moving Panel Out");
            panel.transform.localPosition = Vector3.Lerp(panel.transform.localPosition, targetPosOffCam, moveSpeed * Time.deltaTime);
            float newAlpha = Mathf.Lerp(transparentBackground.color.a, 0, moveSpeed * Time.deltaTime);

        } else {
            // Stop the panel from moving
            moveOut = false;
            this.gameObject.SetActive(false);
        }
    }

    public void ToggleMoveIn(bool gameOverState) {
        moveIn = true;
        moveOut = false;
        gameOver = gameOverState;
    }

    public void ToggleMoveOut(bool gameOverState) {
        moveOut = true;
        moveIn = false;
        gameOver = gameOverState;
    }
}
