using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyUI : MonoBehaviour {

	public List<Image> organObjects;

	public float fadeTime;
	public float displayTime;

	Dictionary<OrganType, float> organHighlightTimes;
	Dictionary<OrganType, Color> organColors;

	BodyController controller;

	private void OnEnable()
	{
		controller = GetComponent<BodyController> ();
		organHighlightTimes = new Dictionary<OrganType, float> ();
		organColors = new Dictionary<OrganType, Color> ();

		for (int i=0; i<organObjects.Count; i++) {
			organObjects [i].enabled = false;
			organColors.Add((OrganType)i, organObjects[i].color);
		}
	}

	public void HighlightOrgan(OrganType organ)
	{
		if (!organHighlightTimes.ContainsKey (organ))
			organHighlightTimes.Add (organ, Time.realtimeSinceStartup);
		else
			organHighlightTimes [organ] = Time.realtimeSinceStartup;

		organObjects [(int)organ].enabled = true;
		organObjects [(int)organ].color = Color.clear;

	}

	void UnhighlightOrgan(OrganType organ)
	{
		if (organHighlightTimes.ContainsKey (organ))
			organHighlightTimes.Remove (organ);

		organObjects [(int)organ].enabled = false;
	}

	void Update()
	{
		List<OrganType> toremove = new List<OrganType> ();

		foreach (KeyValuePair<OrganType, float> organTime in organHighlightTimes) 
		{
			float timePassed = Time.realtimeSinceStartup - organTime.Value;

			if(timePassed <= fadeTime)
			{
				float fadein = timePassed / fadeTime;
				organObjects[(int)organTime.Key].color = Color.Lerp(Color.clear, organColors[organTime.Key], fadein);
			}
			else if(timePassed >= fadeTime + displayTime &&
			        timePassed <= displayTime + fadeTime*2)
			{
				float fadeout = (timePassed - fadeTime - displayTime) / fadeTime;
				organObjects[(int)organTime.Key].color = Color.Lerp(organColors[organTime.Key], Color.clear, fadeout);
			}
			else if(timePassed >= displayTime + fadeTime*2)
			{
				toremove.Add(organTime.Key);
			}
		}

		for(int i=0; i<toremove.Count; i++)
			UnhighlightOrgan(toremove[i]);
	}
}
