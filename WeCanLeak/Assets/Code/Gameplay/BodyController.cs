using UnityEngine;
using System.Collections.Generic;

public class BodyController : MonoBehaviour {

	public Dictionary<JuiceType, int> juicePool = new Dictionary<JuiceType, int>();

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
}
