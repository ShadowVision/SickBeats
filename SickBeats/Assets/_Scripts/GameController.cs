using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager.startTrack ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
