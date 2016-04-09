using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrganUI : MonoBehaviour {

	private Organ organ;
	public List<Button> buttons;

	private void OnEnable()
	{
		organ = Resources.Load<GameObject> ("OrganSettings").GetComponent<OrganSettings>().organs[0];
		foreach (Button b in buttons)
		{
			if (buttons.FindIndex 
			b.onClick.AddListener (OnProducerClicked)
			b.onClick.AddListener (OnConsumerClicked)
		}
	}
	
	private void OnDisable()
	{
		
	}
	
	private void OnConsumerClicked()
	{
		
	}

	private void OnProducerClicked()
	{
		
	}
}
