using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Loads the avatar customization options from AvatarSaver.cs to a selected avatar
/// </summary>

[DisallowMultipleComponent]
public class AvatarLoader : MonoBehaviour {

	[SerializeField] Image hairBackOutline;
	[SerializeField] Image hairBackPaint;
	[SerializeField] Image hairFrontOutline;
	[SerializeField] Image hairFrontPaint;
	[SerializeField] Image eyeImage;
	[SerializeField] Image headPaint;
	[SerializeField] Image bodyPaint;
	[SerializeField] Image topOutline;
	[SerializeField] Image topPaint;
	[SerializeField] Image bottomsOutline;
	[SerializeField] Image bottomsPaint;
	[SerializeField] Image shoeOutline;
	[SerializeField] Image shoePaint;


	void OnEnable () {
		
		LoadData ();
	}

	void LoadData () {

		GameObject avatarSaverGameObject = GameObject.FindGameObjectWithTag ("Avatar Saver");
		AvatarSaver avatarSaver = null;

		if (avatarSaverGameObject) {

			avatarSaver = avatarSaverGameObject.GetComponent<AvatarSaver> ();
		}

		// Check to see if can load and there is data to load
		if (avatarSaver && avatarSaver.GetHairBackOutline() != null) {


			if (avatarSaver.GetHairBackOutline().name == "RoundCornerSquare") {

				hairBackOutline.gameObject.SetActive (false);
				hairBackPaint.gameObject.SetActive (false);
			}
			else {

				hairBackOutline.gameObject.SetActive (true);
				hairBackPaint.gameObject.SetActive (true);

				hairBackOutline.sprite = avatarSaver.GetHairBackOutline ();
				hairBackPaint.sprite = avatarSaver.GetHairBackPaint ();
				hairBackPaint.color = avatarSaver.GetHairColor ();
			}

			hairFrontOutline.sprite = avatarSaver.GetHairFrontOutline ();
			hairFrontPaint.sprite = avatarSaver.GetHairFrontPaint ();
			hairFrontPaint.color = avatarSaver.GetHairColor ();

			eyeImage.sprite = avatarSaver.GetEyeSprite ();

			headPaint.color = avatarSaver.GetSkinColor ();
			bodyPaint.color = avatarSaver.GetSkinColor ();

			topOutline.sprite = avatarSaver.GetTopOutline ();
			topPaint.sprite = avatarSaver.GetTopPaint ();
			topPaint.color = avatarSaver.GetTopColor ();

			bottomsOutline.sprite = avatarSaver.GetBottomsOutline ();
			bottomsPaint.sprite = avatarSaver.GetBottomsPaint ();
			bottomsPaint.color = avatarSaver.GetBottomsColor ();

			shoeOutline.sprite = avatarSaver.GetShoeOutline ();
			shoePaint.sprite = avatarSaver.GetShoePaint ();
			shoePaint.color = avatarSaver.GetShoeColor ();
		}
	}
}
