using UnityEngine;
using System.Collections;

public class DebugControls : MonoBehaviour {
	public static DebugControls instance;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = (DebugControls)this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}else if(Input.GetKey(KeyCode.F5)){
			Libonati.reloadLevel();
		}else if(Input.GetKey(KeyCode.Period)){
			Libonati.loadNextLevel();
		}else if(Input.GetKey(KeyCode.Comma)){
			Libonati.loadPrevLevel();
		}
	}
}
