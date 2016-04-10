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
}
