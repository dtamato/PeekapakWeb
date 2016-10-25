using UnityEngine;
using System.Collections;

public class IconScript : MonoBehaviour {

    EmotionalJourneyGameController gameController;

    [SerializeField] float speed = 2.0f;
    [SerializeField] float maxRotation = 25.0f;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EmotionalJourneyGameController>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();    
	}

    void Rotate() {
        transform.rotation = Quaternion.Euler(0, 0, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
