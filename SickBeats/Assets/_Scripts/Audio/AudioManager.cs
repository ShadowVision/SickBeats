using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : BeatListener {
	public static AudioManager instance;

	public float bpm{
		get{
			if(currentTrack != null){
				return currentTrack.bpm;
			}
			return 0;
		}
	}
	public List<BeatListener> listeners;

	public AudioTrack currentTrack;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = (AudioManager)this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTrack != null && currentTrack.playing) {

		}
	}
	public void addListener(BeatListener newListener){
		if (newListener != (BeatListener)this) {
			listeners.Add (newListener);
		}
	}
	public void removeListener(BeatListener oldListener){
		listeners.Remove (oldListener);
	}
	public void startTrack(){
		currentTrack.manager = (AudioManager)this;
		currentTrack.play ();
	}
	
	override public void OnAudioBeat(AudioTrack.TimeStep timeStep){
		base.OnAudioBeat (timeStep);
		foreach (BeatListener beat in listeners) {
			beat.OnAudioBeat(timeStep);
		}
	}

	public float timeUntilNextBeat(AudioTrack.TimeStep timeStep){
		return currentTrack.timeUntilNextBeat (timeStep);
	}
}
