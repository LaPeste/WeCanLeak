using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BodyTimeController : MonoBehaviour {

	Text text;
	float timeStarted;

	float lastTime;

	Vector3 initSize;

	Color targetColor;

	bool gameover;

	void OnEnable()
	{
		text = GetComponent<Text> ();
		timeStarted = Time.realtimeSinceStartup;
		lastTime = timeStarted;
		initSize = text.transform.localScale;
	}

	void Update()
	{
		text.text = (Time.realtimeSinceStartup - timeStarted).ToString("00") + " seconds";

		if (Time.realtimeSinceStartup - lastTime >= 1f) {
			lastTime = Time.realtimeSinceStartup;
			targetColor = new Color(Random.Range(0f,0.2f), Random.Range(0f,0.2f), Random.Range(0.5f,1f), 1);
		}

		text.color = Color.Lerp (text.color, targetColor, Time.realtimeSinceStartup - lastTime);

		if (gameover) {
			text.transform.localScale = Vector3.Lerp(text.transform.localScale, initSize * 10, Time.realtimeSinceStartup - lastTime);
		}
		else
		{
			text.transform.localScale = initSize * (1 + Mathf.Sin (Time.realtimeSinceStartup)/10f);
		}
	}

	public void GameOver()
	{
		gameover = true;
	}
}
