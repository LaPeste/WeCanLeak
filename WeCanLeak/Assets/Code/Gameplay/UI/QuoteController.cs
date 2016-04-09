using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuoteController : MonoBehaviour {

	public Text text;
	float lastTime;
	Vector3 initSize;
	
	Color targetColor;

	public List<string> quotes;

	void OnEnable()
	{
		text = GetComponent<Text> ();
		lastTime = Time.realtimeSinceStartup;
		initSize = text.transform.localScale;
	}
	
	void Update()
	{
		if (Time.realtimeSinceStartup - lastTime >= 5f) {
			lastTime = Time.realtimeSinceStartup;
			targetColor = new Color(Random.Range(0f,0.2f), Random.Range(0f,0.2f), Random.Range(0.5f,1f), 1);
			text.text = quotes[Random.Range(0, quotes.Count)];
		}
		
		text.color = Color.Lerp (text.color, targetColor, Time.realtimeSinceStartup - lastTime);
		
		text.transform.localScale = initSize * (1 + Mathf.Sin (Time.realtimeSinceStartup)/10f);
	}
}
