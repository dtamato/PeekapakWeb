using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class TopCustomization : MonoBehaviour {

	[SerializeField] Image avatarTopPaint;
	[SerializeField] Image avatarTopOutline;


	public void ChangeTopPaint (Sprite newTopPaint) {

		avatarTopPaint.sprite = newTopPaint;
	}

	public void ChangeTopOutline (Sprite newTopOutline) {

		avatarTopOutline.sprite = newTopOutline;
	}

	public void ChangeTopColor() {

		avatarTopPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}

	public Sprite GetTopOutline () {

		return avatarTopOutline.sprite;
	}

	public Sprite GetTopPaint () {

		return avatarTopPaint.sprite;
	}

	public Color GetTopColor () {

		return avatarTopPaint.color;
	}
}
