using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class ShoeCustomization : MonoBehaviour {

	[SerializeField] Image avatarShoeOutline;
	[SerializeField] Image avatarShoePaint;


	public void ChangeShoeOutline (Sprite newShoeOutline) {

		avatarShoeOutline.sprite = newShoeOutline;
	}

	public void ChangeShoePaint (Sprite newShoePaint) {

		avatarShoePaint.sprite = newShoePaint;
	}

	public void ChangeShoeColor () {

		avatarShoePaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}
}
