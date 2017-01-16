using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DisallowMultipleComponent]
public class HairCustomization : MonoBehaviour {

	[SerializeField] Image hairBackOutline;
	[SerializeField] Image hairBackPaint;

	[SerializeField] Image hairFrontOutline;
	[SerializeField] Image hairFrontPaint;

	[SerializeField] Sprite roundCornerSquare;


	public void ChangeFrontHairOutline (Sprite newFrontHairOutline) {

		hairFrontOutline.sprite = newFrontHairOutline;
	}

	public void ChangeFrontHairPaint(Sprite newFrontHairPaint) {

		hairFrontPaint.sprite = newFrontHairPaint;
	}

	public void ChangeBackHairOutline (Sprite newBackHairOutline) {

		hairBackOutline.sprite = newBackHairOutline;
	}

	public void ChangeBackHairPaint (Sprite newBackHairPaint) {

		hairBackPaint.sprite = newBackHairPaint;
	}

	public void ClearBackHair () {

		hairBackPaint.sprite = roundCornerSquare;
		hairBackOutline.sprite = roundCornerSquare;
	}

	public void ChangeHairColor () {

		hairFrontPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
		hairBackPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}

	public Sprite GetBackHairOutline () {

		return hairBackOutline.sprite;
	}

	public Sprite GetBackHairPaint () {

		return hairBackPaint.sprite;
	}

	public Sprite GetFrontHairOutline () {

		return hairFrontOutline.sprite;
	}

	public Sprite GetFrontHairPaint () {
		
		return hairFrontPaint.sprite;
	}

	public Color GetHairColor () {

		return hairBackPaint.color;
	}
}
