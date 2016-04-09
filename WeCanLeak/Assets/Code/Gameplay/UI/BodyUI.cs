using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyUI : MonoBehaviour {

	public List<Image> organObjects;

	public float fadeTime;
	public float displayTime;

	Dictionary<OrganType, float> organHighlightTimes;

	BodyController controller;

	private void OnEnable()
	{
		controller = GetComponent<BodyController> ();
		organHighlightTimes = new Dictionary<OrganType, float> ();
	}

	public void HighlightOrgan(OrganType organ)
	{
		if (!organHighlightTimes.ContainsKey (organ))
			organHighlightTimes.Add (organ, Time.realtimeSinceStartup);
		else
			organHighlightTimes [organ] = Time.realtimeSinceStartup;

	}

	void UnhighlightOrgan(OrganType organ)
	{
		if (organHighlightTimes.ContainsKey (organ))
			organHighlightTimes.Remove (organ);
	}

	void Update()
	{
		List<OrganType> toremove = new List<OrganType> ();

		foreach (KeyValuePair<OrganType, float> organTime in organHighlightTimes) {
			if(Time.realtimeSinceStartup - organTime.Value <= fadeTime)
			{
				float fadein = (Time.realtimeSinceStartup - organTime.Value) / fadeTime;
				organObjects[(int)organTime.Key].color = Color.Lerp(Color.clear, organObjects[(int)organTime.Key].color, fadein);
			}
			else if(Time.realtimeSinceStartup - organTime.Value >= displayTime &&
			        Time.realtimeSinceStartup - organTime.Value <= displayTime + fadeTime)
			{
				float fadeout = (Time.realtimeSinceStartup - organTime.Value) / (displayTime + fadeTime*2);
				organObjects[(int)organTime.Key].color = Color.Lerp(organObjects[(int)organTime.Key].color, Color.clear, fadeout);
			}
			else if(Time.realtimeSinceStartup - organTime.Value >= displayTime + fadeTime*2)
			{
				toremove.Add(organTime.Key);
			}
		}

		for(int i=0; i<toremove.Count; i++)
			UnhighlightOrgan(toremove[i]);
	}
}
