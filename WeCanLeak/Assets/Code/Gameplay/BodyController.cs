using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyController : MonoBehaviour {

	public Dictionary<JuiceType, int> juicePool = new Dictionary<JuiceType, int>();

	public List<Color> pureJuiceColors;

	public Image tubes;

	public BodyUI bodyui;

	public void AddToPool(JuiceType juiceType, int amount)
	{
		if (!juicePool.ContainsKey (juiceType))
			juicePool.Add (juiceType, amount);
		else
			juicePool [juiceType] += amount;

	}

	[PunRPC]
	public int ReleaseAndUpdateFromPool(JuiceType juiceType, int amount)
	{
		int result = juicePool [juiceType];
		if (juicePool.ContainsKey (juiceType)) 
		{
			if(juicePool [juiceType] - amount >= 0)
			{
				juicePool [juiceType] -= amount;
				result = amount;
			}
			else
			{
				result = juicePool [juiceType];
				juicePool [juiceType] = 0;
			}
		}
		return result;
	}

	[PunRPC]
	public int AmountInPool(JuiceType juiceType)
	{
		if (!juicePool.ContainsKey (juiceType))
			return 0;
		return juicePool [juiceType];
	}

	public Color GetPoolColor()
	{
		Color ret = Color.black;
		int inPool = 0;

		foreach (KeyValuePair<JuiceType, int> juice in juicePool) {
			ret += pureJuiceColors[(int)juice.Key] * (juice.Value / 10f);
			inPool += juice.Value;
		}

		Debug.Log (inPool);

		return ret;
	}

	private void Update()
	{
		tubes.color = GetPoolColor ();
	}

	public void OrganHealthUpdated(OrganType organ, int health)
	{
		// TODO
	}
	
	public void OrganReleaseJuice(OrganType organ, JuiceType juice, int amount)
	{
		AddToPool(juice, amount);

		bodyui.HighlightOrgan (organ);
	}
	
	public void OrganRequestJuice(OrganType organ, JuiceType juice, int amount)
	{
		ReleaseAndUpdateFromPool (juice, amount);

		bodyui.HighlightOrgan (organ);
	}
}
