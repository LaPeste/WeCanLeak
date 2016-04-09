using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyController : MonoBehaviour {

	public Dictionary<JuiceType, int> juicePool = new Dictionary<JuiceType, int>();

	public List<Color> pureJuiceColors;

	public Image tubes;

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

	public void OrganHealthUpdated(OrganType organ, int health)
	{
		
	}
	
	public void OrganReleaseJuice(OrganType organ, JuiceType juice, int amount)
	{
	}
	
	public void OrganRequestJuice(OrganType organ, JuiceType juice, int amount)
	{
	}
}
