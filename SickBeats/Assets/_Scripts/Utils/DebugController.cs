using UnityEngine;
using System.Collections;

public class DebugController : MonoBehaviour {

	public GameObject[] debugMeshes;
	public bool debugging{
		get{
			return !hidden;
		}
	}
	private bool hidden = true;

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 60;
	}
	void Start(){

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.D)){
			toggleDebug();
		}
		if(Input.GetKeyUp(KeyCode.F5)){
			Libonati.reloadLevel();
		}
		if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();
		}
	}

	private void toggleDebug(){
		if(hidden){
			showDebug();
		}else{
			hideDebug();
		}
	}
	public void showDebug(){
		hidden = false;
		foreach(GameObject obj in debugMeshes){
			Libonati.showAllMesh(obj);
		}
	}
	public void hideDebug(){
		hidden = true;
		foreach(GameObject obj in debugMeshes){
			Libonati.hideAllMesh(obj);
		}
	}
}
