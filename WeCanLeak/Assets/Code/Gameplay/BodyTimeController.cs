using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BodyTimeController : MonoBehaviour {

	Text text;
	float timeStarted;

	void OnEnable()
	{
		text = GetComponent<Text> ();
		timeStarted = Time.realtimeSinceStartup;
	}

	void Update()
	{
		text.text = (Time.realtimeSinceStartup - timeStarted).ToString("00") + " seconds";
	}


}
