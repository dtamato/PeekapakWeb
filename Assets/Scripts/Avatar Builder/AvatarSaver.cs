using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Saves avatar customization options in order for other scenes to update the avatar
/// </summary>

[DisallowMultipleComponent]
public class AvatarSaver : MonoBehaviour {
	
	public static AvatarSaver instance = null;
	GameObject avatarCustomizer;

	Sprite hairBackOutline;
	Sprite hairBackPaint;
	Sprite hairFrontOutline;
	Sprite hairFrontPaint;
	Color hairColor;

	Sprite eyeSprite;

	Color skinColor;

	Sprite topOutline;
	Sprite topPaint;
	Color topColor;

	Sprite bottomsOutline;
	Sprite bottomsPaint;
	Color bottomsColor;

	Sprite shoeOutline;
	Sprite shoePaint;
	Color shoeColor;


	void Awake () {

		// Singleton control
		if (instance == null) {

			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else if (instance != this) {

			Destroy (this.gameObject);
		}
	}

	public void SaveData (GameObject avatarCustomizer) {

		if (avatarCustomizer) {

			HairCustomization hairCustomization = avatarCustomizer.GetComponentInChildren<HairCustomization> ();
			hairBackOutline = hairCustomization.GetBackHairOutline ();
			hairBackPaint = hairCustomization.GetBackHairPaint ();
			hairFrontOutline = hairCustomization.GetFrontHairOutline ();
			hairFrontPaint = hairCustomization.GetFrontHairPaint ();
			hairColor = hairCustomization.GetHairColor ();

			// Get eye data
			EyeCustomization eyeCustomization = avatarCustomizer.GetComponentInChildren<EyeCustomization>();
			eyeSprite = eyeCustomization.GetEyeSprite ();

			// Get skin data
			SkinCustomization skinCustomization = avatarCustomizer.GetComponentInChildren<SkinCustomization>();
			skinColor = skinCustomization.GetSkinColor ();

			// Get top data
			TopCustomization topCustomization = avatarCustomizer.GetComponentInChildren<TopCustomization>();
			topOutline = topCustomization.GetTopOutline ();
			topPaint = topCustomization.GetTopPaint ();
			topColor = topCustomization.GetTopColor ();

			// Get bottom data
			BottomsCustomization bottomsCustomization = avatarCustomizer.GetComponentInChildren<BottomsCustomization>();
			bottomsOutline = bottomsCustomization.GetBottomsOutline ();
			bottomsPaint = bottomsCustomization.GetBottomsPaint ();
			bottomsColor = bottomsCustomization.GetBottomsColor ();

			// Get shoe data
			ShoeCustomization shoeCustomization = avatarCustomizer.GetComponentInChildren<ShoeCustomization>();
			shoeOutline = shoeCustomization.GetShoeOutline ();
			shoePaint = shoeCustomization.GetShoePaint ();
			shoeColor = shoeCustomization.GetShoeColor ();
		}
	}

	#region AvatarGetters
	public Sprite GetHairBackOutline () {

		return hairBackOutline;
	}

	public Sprite GetHairBackPaint () {

		return hairBackPaint;
	}

	public Sprite GetHairFrontOutline () {

		return hairFrontOutline;
	}

	public Sprite GetHairFrontPaint () {

		return hairFrontPaint;
	}

	public Color GetHairColor () {

		return hairColor;
	}

	public Sprite GetEyeSprite () {

		return eyeSprite;
	}

	public Color GetSkinColor () {

		return skinColor;
	}

	public Sprite GetTopOutline () {

		return topOutline;
	}

	public Sprite GetTopPaint () {

		return topPaint;
	}

	public Color GetTopColor () {

		return topColor;
	}

	public Sprite GetBottomsOutline () {

		return bottomsOutline;
	}

	public Sprite GetBottomsPaint () {

		return bottomsPaint;
	}

	public Color GetBottomsColor () {

		return bottomsColor;
	}

	public Sprite GetShoeOutline () {

		return shoeOutline;
	}

	public Sprite GetShoePaint () {

		return shoePaint;
	}

	public Color GetShoeColor () {

		return shoeColor;
	}
	#endregion
}
