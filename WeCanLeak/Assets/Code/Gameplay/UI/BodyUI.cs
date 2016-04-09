using UnityEngine;
using System.Collections.Generic;

public class BodyUI : MonoBehaviour {

	public List<GameObject> organObjects;

	BodyController controller;

	private void OnEnable()
	{
		controller = GetComponent<BodyController> ();
	}

	public void OrganHealthUpdated(int organIndex)
	{

	}
}
