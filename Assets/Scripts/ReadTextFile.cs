using UnityEngine;
using System.Collections;

public class ReadTextFile : MonoBehaviour {

    [SerializeField] TextAsset testTA;

    string[] linesInFile;

	// Use this for initialization
	void Start () {
        // Read in and break for every new line
        linesInFile = testTA.text.Split('\n');

        foreach (string line in linesInFile) {
            Debug.Log(line);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
