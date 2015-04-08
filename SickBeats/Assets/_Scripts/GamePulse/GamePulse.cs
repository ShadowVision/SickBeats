using UnityEngine;
using System.Collections;

public class GamePulse : BeatListener {
	public AudioTrack.TimeStep timeStep = AudioTrack.TimeStep.WHOLE;
	public float pulseScale = 1.5f;
	public float pulseHoldInSeconds = .1f;
	public Lerp_Basic pulseObject;
	public Lerp_Basic secondaryObject;

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
			Invoke ("stopAudioBeat", pulseHoldInSeconds);
		}
	}

	private void stopAudioBeat(){
		pulseObject.targetScale = new Vector3 (1, 1, 1);
	}
}
