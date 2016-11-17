using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class TempMapTranslation : MonoBehaviour {

	[SerializeField] float moveSpeed = 1;
	[SerializeField] float leftBoundary;
	[SerializeField] float rightBoundary;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetAxis ("Horizontal") != 0) {

			this.transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Vector3.left);

			float newX = this.transform.position.x;
			newX = Mathf.Clamp (newX, leftBoundary, rightBoundary);
			this.transform.position = new Vector3 (newX, 0, 0);
		}
	}
}
