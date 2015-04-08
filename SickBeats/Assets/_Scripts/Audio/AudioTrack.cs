using UnityEngine;
using System.Collections;

public class AudioTrack : MonoBehaviour {
	public enum TimeStep
	{
		WHOLE,
		HALF,
		QUARTER,
		EIGTH,
		SIXTEENTH
	}
	public float bpm = 120;
	public TimeStep timeStep = TimeStep.WHOLE;
	public float currentTime = 0;
	public bool playing = false;

	[HideInInspector]
	public AudioManager manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		playing = true;
		InvokeRepeating ("OnAudioBeat_Whole", 0, bpm / 60);
		InvokeRepeating ("OnAudioBeat_Half", bpm / 60 / 2, bpm / 60 / 2);
		InvokeRepeating ("OnAudioBeat_Quarter", bpm / 60 / 4, bpm / 60 / 4);
	}
	public void stop(){
		playing = false;
	}
	
	protected virtual void OnAudioBeat_Whole(){
		Debug.Log ("WHOLE BEAT");
		manager.OnAudioBeat (TimeStep.WHOLE);
	}
	protected virtual void OnAudioBeat_Half(){
		Debug.Log ("HALF BEAT");
		manager.OnAudioBeat (TimeStep.HALF);
	}
	protected virtual void OnAudioBeat_Quarter(){
		Debug.Log ("QUARTER BEAT");
		manager.OnAudioBeat (TimeStep.QUARTER);
	}
}
