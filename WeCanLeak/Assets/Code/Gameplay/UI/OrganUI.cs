using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrganUI : MonoBehaviour {

	public Button juice1;
	public Button juice2;
	public Button juice3;
	public Button juice4;
	private Organ organ;

	private void OnEnable()
	{
		organ = Resources.Load<GameObject> ("OrganSettings").GetComponent<OrganSettings>().organs[0];

		juice1.onClick.AddListener (OnJuice1Clicked);
		juice2.onClick.AddListener (OnJuice2Clicked);
		juice3.onClick.AddListener (OnJuice3Clicked);
		juice4.onClick.AddListener (OnJuice4Clicked);
	}
	
	private void OnDisable()
	{
		juice1.onClick.RemoveListener (OnJuice1Clicked);
		juice2.onClick.RemoveListener (OnJuice2Clicked);
		juice2.onClick.RemoveListener (OnJuice3Clicked);
		juice2.onClick.RemoveListener (OnJuice4Clicked);
	}
	
	private void OnJuice1Clicked()
	{

	}

	private void OnJuice2Clicked()
	{
		
	}

	private void OnJuice3Clicked()
	{
		
	}

	private void OnJuice4Clicked()
	{
		
	}
}
