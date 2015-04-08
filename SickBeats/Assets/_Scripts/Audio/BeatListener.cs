using UnityEngine;
using System.Collections;

public class BeatListener : MonoBehaviour {
	protected AudioManager audioManager;
	// Use this for initialization
	protected void Start () {
		audioManager = AudioManager.instance;
		audioManager.addListener ((BeatListener)this);
	}
	protected void OnDestroy(){
		audioManager.removeListener ((BeatListener)this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnAudioBeat(AudioTrack.TimeStep timeStep){

	}

}
