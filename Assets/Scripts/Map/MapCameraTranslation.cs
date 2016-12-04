using UnityEngine;

[DisallowMultipleComponent]
public class MapCameraTranslation : MonoBehaviour {

	[SerializeField] float moveSpeed = 1;
	[SerializeField] float leftBoundary;
	[SerializeField] float rightBoundary;


	void Start () {
	
		this.transform.position = new Vector3 (leftBoundary, this.transform.position.y, this.transform.position.z);
	}

	void Update () {
	

		if (Input.GetAxis ("Horizontal") != 0) {

			this.transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Vector3.right);

			float newX = this.transform.position.x;
			newX = Mathf.Clamp (newX, leftBoundary, rightBoundary);
			this.transform.position = new Vector3 (newX, this.transform.position.y, this.transform.position.z);
		}
	}
}
