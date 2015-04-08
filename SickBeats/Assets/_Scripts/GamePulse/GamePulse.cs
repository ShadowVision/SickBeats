using UnityEngine;
using System.Collections;

public class GamePulse : BeatListener {
	public AudioTrack.TimeStep timeStep = AudioTrack.TimeStep.WHOLE;
	public float pulseScale = 1.5f;
	public float secondaryPulseScale = 1.5f;
	public float pulseHoldInSeconds = .1f;
	public Lerp_Basic pulseObject;
	public TimedLerp_Basic secondaryObject;

	// Use this for initialization
	new void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnAudioBeat (AudioTrack.TimeStep timeStep)
	{
		base.OnAudioBeat (timeStep);
		if (this.timeStep == timeStep) {
			pulseObject.targetScale = new Vector3 (pulseScale, pulseScale, pulseScale);
			secondaryObject.transform.localScale = new Vector3(secondaryPulseScale,secondaryPulseScale,secondaryPulseScale);
			secondaryObject.scaleLengthInSeconds = audioManager.timeUntilNextBeat(timeStep);
			secondaryObject.scaleTo(Vector3.one);
			Invoke ("stopAudioBeat", pulseHoldInSeconds);
		}
	}

	private void stopAudioBeat(){
		pulseObject.targetScale = new Vector3 (1, 1, 1);
	}
}
