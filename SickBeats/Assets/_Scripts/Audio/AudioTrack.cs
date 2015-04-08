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
	
	private float[] lastBeatTimes;
	private float[] beatTimes;

	// Use this for initialization
	void Awake () {
		lastBeatTimes = new float[5];
		beatTimes = new float[5];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		playing = true;
		beatTimes [(int)TimeStep.WHOLE] = bpm / 60;
		beatTimes [(int)TimeStep.HALF] = bpm / 60 /2;
		beatTimes [(int)TimeStep.QUARTER] = bpm / 60 /4;
		beatTimes [(int)TimeStep.EIGTH] = bpm / 60 /8;
		beatTimes [(int)TimeStep.SIXTEENTH] = bpm / 60 /16;
		InvokeRepeating ("OnAudioBeat_Whole", 0, beatTimes[(int)TimeStep.WHOLE]);
		InvokeRepeating ("OnAudioBeat_Half", beatTimes[(int)TimeStep.HALF],beatTimes[(int)TimeStep.HALF]);
		InvokeRepeating ("OnAudioBeat_Quarter", beatTimes[(int)TimeStep.QUARTER],beatTimes[(int)TimeStep.QUARTER]);
	}
	public void stop(){
		playing = false;
	}
	private void OnBeat(TimeStep timeStep){
		lastBeatTimes [(int)timeStep] = Time.time;
		manager.OnAudioBeat (timeStep);
	}
	protected virtual void OnAudioBeat_Whole(){
		OnBeat (TimeStep.WHOLE);
	}
	protected virtual void OnAudioBeat_Half(){
		OnBeat (TimeStep.HALF);
	}
	protected virtual void OnAudioBeat_Quarter(){
		OnBeat (TimeStep.QUARTER);
	}
	public float timeUntilNextBeat(AudioTrack.TimeStep timeStep){
		return lastBeatTimes[(int)timeStep] + beatTimes[(int)timeStep] - Time.time;
	}
}
