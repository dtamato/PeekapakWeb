using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Detects whether the player has swiped left or right on a mobile
/// device based on the velocity of the touch
/// </summary>

[DisallowMultipleComponent]
public class VelocityBasedSwiping : MonoBehaviour {

    [SerializeField, Range(0, 1), Tooltip("Percentage of the screen the swipe needs to be to count as a swipe.")] 
    float swipePercentage = 0.5f;

    float minimumSwipeSize;

	MapCameraController cameraController;

	void Awake () {

		cameraController = this.GetComponent<MapCameraController> ();
	}

    void Update () {

        WaitForTouch();
    }

    void WaitForTouch () {

        if(Input.touchCount == 1) {

            switch (Input.GetTouch(0).phase) {

                case TouchPhase.Moved:

                    ProcessSwipe(Input.GetTouch(0).deltaPosition.x);
                    break;
            }
        }
    }

    void ProcessSwipe (float xSpeed) {

        if(xSpeed > minimumSwipeSize) {

            Debug.Log("Swiped right!");
			cameraController.MoveCamera (1);
        }
        else if(xSpeed < -minimumSwipeSize) {

			cameraController.MoveCamera (-1);
        }
    }
}
