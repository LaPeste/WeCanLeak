using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {

	Camera cam;

	float lastUpdated;
	Color rndColor;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		lastUpdated = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - lastUpdated >= 1f) {
			lastUpdated = Time.realtimeSinceStartup;

			rndColor = new Color(Random.Range(0.5f,1f), Random.Range(0.1f,0.5f), Random.Range(0f,0.2f), 1);

		}

		cam.backgroundColor = Color.Lerp (cam.backgroundColor, rndColor, Time.realtimeSinceStartup - lastUpdated);
	}
}
