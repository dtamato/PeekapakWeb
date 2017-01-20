using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Loads the avatar customization options from AvatarSaver.cs to a selected avatar
/// </summary>

[DisallowMultipleComponent]
public class AvatarLoader : MonoBehaviour {

	[Header("Data References")]
	[SerializeField] Text nameText;

	[Header("Avatar References")]
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
		LoadSprites ();
	}

	void LoadData () {

		if (nameText != null && PlayerPrefs.HasKey ("playerName")) {

			if (nameText.GetComponent<InputField> ()) {

				nameText.GetComponent<InputField> ().text = PlayerPrefs.GetString ("playerName");
			}
			else {

				nameText.text = PlayerPrefs.GetString ("playerName");
			}
		}
	}

	void LoadSprites () {

		GameObject avatarSaverGameObject = GameObject.FindGameObjectWithTag ("Avatar Saver");
		AvatarSaver avatarSaver = null;

		if (avatarSaverGameObject) {

			avatarSaver = avatarSaverGameObject.GetComponent<AvatarSaver> ();
		}

		// Check to see if can load and there is data to load
		if (avatarSaver && avatarSaver.GetHairFrontOutline() != null) {

			if (avatarSaver.GetHairBackOutline() == null) {

				hairBackOutline.sprite = null;
				hairBackPaint.sprite = null;

				hairBackOutline.color = Color.clear;
				hairBackPaint.color = Color.clear;
			}
			else {

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
