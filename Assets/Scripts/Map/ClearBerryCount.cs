using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClearBerryCount : MonoBehaviour {

    [SerializeField] BerryUIController berryUIController;
    [SerializeField] PlayerData playerData;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            playerData.SetUpPlayerData();
            berryUIController.UpdateBerryCount();
            SceneManager.LoadScene("Map");
        }
	}
}
