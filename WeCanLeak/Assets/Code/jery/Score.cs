using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
			
	void OnGUI()
	{
		GUI.Label (new Rect(5, 250, 200, 50), ("score = " + score));
	}
}
