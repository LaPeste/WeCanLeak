using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {
	public AudioSource audio_titleA;
	public AudioSource audio_titleB;
	
	Object[] AudioArray_loopable;
	
	public float bpm = 100.0F;
	public int beatsPerMeasure = 4;
	private double singleMeasureTime;
	private double delayEvent;
	private bool running = false;
	private int i;
	
	// Use this for initialization
	void Start () {
		bpm = 100.0F;
		beatsPerMeasure = 4;
		int i = 0;
		singleMeasureTime = AudioSettings.dspTime + 2.0F;
		running = true;
		
		
		
		
		//Load the GUITAR A samples into the AudioClip Array
		audio_titleA = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_titleB = (AudioSource)gameObject.AddComponent <AudioSource>();
		AudioArray_loopable = Resources.LoadAll("loopable",typeof(AudioClip));
		

		audio_titleA.clip = AudioArray_loopable[1] as AudioClip;
		audio_titleB.clip = AudioArray_loopable[1] as AudioClip;
		
		

		
	}	
	
	// Update is called once per frame
	void Update () {
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			
				
			if (time + 1.0F > singleMeasureTime) {
			
				audio_titleA.PlayScheduled (time);
				
				
			}
		}
		if (i==52 ){
			if (time + 1.0F > singleMeasureTime) {

				audio_titleB.PlayScheduled(time);
				
				
			}
		}
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			i +=1;
			Debug.Log ("The i int equals  " + i);
			if (i==104){
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			Debug.Log("The single measure time is " + singleMeasureTime);
		}
	}
	
	
}