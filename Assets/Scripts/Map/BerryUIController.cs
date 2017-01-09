using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BerryUIController : MonoBehaviour {

    [SerializeField] Text berryCountUI;
    int berryCount = 0;

	// Use this for initialization
	void Start () {
        UpdateBerryCount();
	}

    public void UpdateBerryCount() {
        berryCount = PlayerPrefs.GetInt("berryCount");
        berryCountUI.text = berryCount.ToString();
    }
}
