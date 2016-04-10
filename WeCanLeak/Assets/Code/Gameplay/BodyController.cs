using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class BodyController : MonoBehaviour {

	public Dictionary<JuiceType, int> juicePool = new Dictionary<JuiceType, int>();

	public List<Color> pureJuiceColors;
	public List<Organ> organs;

	public Image tubes;

	public BodyUI bodyui;

	public AudioClip releaseSound1;
	public AudioClip releaseSound2;
	public AudioClip releaseSound3;
	public AudioClip releaseSound4;
	public AudioClip requestSound;
	public AudioClip cellDrySound;
	public AudioClip cellFullSound;
	public AudioClip damageSound; //decreasing health
	public AudioClip gameOverSound;

	public void Awake()
	{
		organs = new List<Organ>();
		for (int i=0; i< Enum.GetValues(typeof(OrganType)).Length; i++)
		{
			organs.Add(new Organ{health = 100, organType = (OrganType)i});
		}
	}

	public void AddToPool(JuiceType juiceType, int amount)
	{
		if (!juicePool.ContainsKey (juiceType))
			juicePool.Add (juiceType, amount);
		else
			juicePool [juiceType] += amount;

	}

	public void RemoveFromPool(JuiceType juiceType, int amount)
	{
		if (juicePool.ContainsKey (juiceType))
			juicePool [juiceType] -= amount;

		if (juicePool [juiceType] < 0)
			juicePool [juiceType] = 0;
	}

	public int AmountInPool(JuiceType juiceType)
	{
		if (!juicePool.ContainsKey (juiceType))
			return 0;
		return juicePool [juiceType];
	}

	public Color GetPoolColor()
	{
		Color ret = Color.black;

		foreach (KeyValuePair<JuiceType, int> juice in juicePool) {
			ret += pureJuiceColors[(int)juice.Key] * (juice.Value / 100);
		}

		return ret;
	}

	private void Update()
	{
		tubes.color = GetPoolColor ();
	}



	public void UpdateOrganHealth(OrganType organ, int health)
	{

	}

	public void OrganHealthUpdated(OrganType organ, int health)
	{
		// TODO
	}
	
	public void OrganReleaseJuice(OrganType organ, JuiceType juice, int amount)
	{
		AddToPool(juice, amount);
		bodyui.HighlightOrgan (organ);
		//Play release sound
		SoundManager.instance.RandomizeSfx(releaseSound1, releaseSound2, releaseSound3, releaseSound4);
	}
	
	public void OrganRequestJuice(OrganType organ, JuiceType juice, int amount)
	{
		RemoveFromPool (juice, amount);

		bodyui.HighlightOrgan (organ);
	}

	public void GameOver ()
	{
		FindObjectOfType<BodyTimeController>().GameOver();
		SoundManager.instance.PlaySingle(gameOverSound);
	}
}
