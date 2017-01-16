using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class BottomsCustomization : MonoBehaviour {

	[SerializeField] Image avatarBottomsPaint;
	[SerializeField] Image avatarBottomsOutline;


	public void ChangeBottomsPaint (Sprite newBottomsPaint) {

		avatarBottomsPaint.sprite = newBottomsPaint;
	}

	public void ChangeBottomsOutline (Sprite newBottomsOutline) {

		avatarBottomsOutline.sprite = newBottomsOutline;
	}

	public void ChangeBottomsColor () {

		avatarBottomsPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}

	public Sprite GetBottomsOutline () {

		return avatarBottomsOutline.sprite;
	}

	public Sprite GetBottomsPaint () {

		return avatarBottomsPaint.sprite;
	}

	public Color GetBottomsColor () {

		return avatarBottomsPaint.color;
	}
}
