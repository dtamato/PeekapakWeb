using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {

    [SerializeField] Vector3 maxSize;
    [SerializeField] Vector3 minSize;
    bool grow = false;
    bool shrink = false;
    float speed = 5;

    // Use this for initialization
    void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	    if (grow) {
            ToggleGrow();
        } if (shrink) {
            ToggleShrink();
        }
	}

     void ToggleGrow() {
        if (this.transform.localScale.y < 1.25f) {
            transform.localScale = Vector3.Lerp(transform.localScale, maxSize, speed * Time.deltaTime);
        } else {
            grow = false;
        }
    }

    void ToggleShrink() {
        if (this.transform.localScale.y > 1) {
            transform.localScale = Vector3.Lerp(transform.localScale, minSize, speed * Time.deltaTime);
        } else {
            shrink = false;
        }
    }

    public void OnPointerEnter() {
        grow = true;
        shrink = false;
    }

    public void OnPointerExit() {
        shrink = true;
        grow = false;
    }

    public void OnPointerDown() {

    }
}
