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


	public void ChangeHairOutline (Sprite newHairOutline) {


	}

	public void ChangeHairColor () {

		hairFrontPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
		hairBackPaint.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
	}
}
