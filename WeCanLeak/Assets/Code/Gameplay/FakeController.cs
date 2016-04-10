using UnityEngine;
using System;
using System.Collections.Generic;

using Random = UnityEngine.Random;

public class FakeController : MonoBehaviour {
	
	public float minReleaseSec;
	public float maxReleaseSec;
	
	public float minRequestSec;
	public float maxRequestSec;
	
	public float healthVariancePerSec;
	
	public float speedupPerSecond;
	float timePassed;
	
	float lastRelease;
	float lastRequest;
	float lastHealthUpdate;
	
	float nextRelease;
	float nextRequest;
	
	List<float> lastHealthValues;
	
	BodyController bodyController;
	
	void Start()
	{
		lastRelease = Time.realtimeSinceStartup;
		nextRelease = Random.Range(minReleaseSec, maxReleaseSec);
		lastRequest = Time.realtimeSinceStartup;
		nextRequest = Random.Range(minRequestSec, maxRequestSec);
		lastHealthUpdate = Time.realtimeSinceStartup;
		lastHealthValues = new List<float> ();
		for (int i=0; i<4; i++)
			lastHealthValues [i] = 100;
		
		bodyController = GetComponent<BodyController> ();
	}
	
	void Update () {
		bodyController = GetComponent<BodyController> ();
		timePassed += Time.deltaTime;
		
		if (Time.realtimeSinceStartup - lastRelease >= nextRelease) {
			lastRelease = Time.realtimeSinceStartup;
			nextRelease = Random.Range(minReleaseSec, maxReleaseSec)-(speedupPerSecond*timePassed);
			
			Debug.Log("RELEASE");
			
			bodyController.OrganReleaseJuice(
				(OrganType)Random.Range(0, Enum.GetValues(typeof(OrganType)).Length), 
				(JuiceType)Random.Range(0, Enum.GetValues(typeof(JuiceType)).Length), 
				Random.Range(3, 10));
		}
		if (Time.realtimeSinceStartup - lastRequest >= nextRequest) {
			lastRequest = Time.realtimeSinceStartup;
			nextRequest = Random.Range(minRequestSec, maxRequestSec)-(speedupPerSecond*timePassed);
			
			Debug.Log("REQUEST");
			
			bodyController.OrganRequestJuice(
				(OrganType)Random.Range(0, Enum.GetValues(typeof(OrganType)).Length), 
				(JuiceType)Random.Range(0, Enum.GetValues(typeof(JuiceType)).Length), 
				Random.Range(3, 10));
		}
		if (Time.realtimeSinceStartup - lastHealthUpdate >= 1) {
			lastHealthUpdate = Time.realtimeSinceStartup;
			// TODO call health updates with random derivation
			Debug.Log("HEALTH");
			
			for(int i=0; i<lastHealthValues.Count; i++)
			{
				if(lastHealthValues[i] > 0)
					lastHealthValues[i] = lastHealthValues[i] + Random.Range(-healthVariancePerSec, healthVariancePerSec);
				
				bodyController.OrganHealthUpdated((OrganType)i, Mathf.RoundToInt(lastHealthValues[i]));
			}
			
		}
	}
}
