using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class SkinCustomization : MonoBehaviour {

	[SerializeField] Image avatarHeadPaint;
	[SerializeField] Image avatarBodyPaint;


	public void ChangeSkinColor () {

		avatarHeadPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
		avatarBodyPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
	}

	public Color GetSkinColor () {

		return avatarHeadPaint.color;
	}
}
