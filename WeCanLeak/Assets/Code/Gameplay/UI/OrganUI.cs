using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrganUI : MonoBehaviour {

	public Button juice1;
	public Button juice2;
	public Button juice3;
	public Button juice4;
	private Organ organ;
	public int juicePerTap = 10; //amount of juice that is requested or, respectively, released per tap

	private int phlegmIndex = 0;
	private int yellowIndex = 1;
	private int blackIndex = 2;
	private int bloodIndex = 3;

	private int selectedOrgan;

	private Transform[] liquid1;
	private Transform[] liquid2;
	private Transform[] liquid3;
	private Transform[] liquid4;

	int producerindex;


	public void Initialize(int selectedOrgan)
	{
		this.selectedOrgan = selectedOrgan;


		//Initializing the liquids
		for (int i = 0; i < 4; i++)
		{

			for (int j = 0; j < liquid1.Length; j++)
			{

			}
		}

		liquid1 = InitializeLiquids(liquid1, juice1);
		liquid2 = InitializeLiquids(liquid2, juice2);
		liquid3 = InitializeLiquids(liquid3, juice3);
		liquid4 = InitializeLiquids(liquid4, juice4);

	}

	private Transform[] InitializeLiquids(Transform[] _liquid, Button _juice)
	{
		_liquid = new Transform[3];
		for (int i = 0; i < _liquid.Length; i++)
		{
			_liquid[i] = _liquid[i].gameObject.transform.GetChild(0).GetChild(i).transform;
		}
		return _liquid;
	}

	private void OnEnable()
	{
		organ = Resources.Load<GameObject> ("OrganSettings").GetComponent<OrganSettings>().organs[selectedOrgan];

		producerindex = organ.juices.FindIndex(j => organ.producer == j.type);

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

	//=================================
	
	public void OnJuice1Clicked()
	{
		CalculateJuices(phlegmIndex, liquid1);
	}

	public void OnJuice2Clicked()
	{
		CalculateJuices(yellowIndex, liquid2);
	}

	public void OnJuice3Clicked()
	{
		CalculateJuices(blackIndex, liquid3);
	}

	public void OnJuice4Clicked()
	{
		CalculateJuices(bloodIndex, liquid4);
	}

	//=================================

	private void CalculateJuices(int _thisProducerIndex, Transform[] _liquid)
	{
		if (producerindex == _thisProducerIndex) //if this organ produces this Juice/Liquid
		{
			organ.juices[_thisProducerIndex].amount -= juicePerTap;
			for(int i = 0; i < _liquid.Length; i++) // Decreases the liquid level in the container
			{
				_liquid[i].localScale = new Vector3(0, _liquid[i].localScale.y - 0.1f, 0);
			}
			NetworkComm.ReleaseJuice( (JuiceType) phlegmIndex ); //release it
		}
		else //if not, request phlegm
		{
			if (NetworkComm.RequestJuice( (JuiceType) phlegmIndex )) //might not be available in the pool right now
			{
				organ.juices[_thisProducerIndex].amount += juicePerTap;
				for(int i = 0; i < _liquid.Length; i++) // Increases the liquid level in the container
				{
					_liquid[i].localScale = new Vector3(0, _liquid[i].localScale.y + 0.1f, 0);
				}
			}
		}
	}



}
