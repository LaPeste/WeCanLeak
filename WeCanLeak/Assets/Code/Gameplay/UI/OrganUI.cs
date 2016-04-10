using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class OrganUI : MonoBehaviour {

	public Button juice1;
	public Button juice2;
	public Button juice3;
	public Button juice4;
	private Organ organ;
	public int juicePerTap = 1; //amount of juice that is requested or, respectively, released per tap

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
			_liquid[i] = _juice.gameObject.transform.GetChild(0).GetChild(i).transform;
			_liquid[i].localScale = new Vector3(1f, 0.5f, 1f); // Levels of liquid initialized at half
			Debug.Log(_liquid[i]);
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

	//==================================================================
	
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

	//==================================================================

	private void CalculateJuices(int _thisProducerIndex, Transform[] _liquid)
	{
		if(organ.health > 0)
		{
			if (producerindex == _thisProducerIndex) //if this organ produces _thisProducerIndex
			{
				organ.health --;
//				Action<int> OnRequestFinished = (int receivedValue) => {
////					organ.juices[_thisProducerIndex].amount -= juicePerTap;
//					organ.juices[_thisProducerIndex].amount -= receivedValue;
//				};
				organ.juices[_thisProducerIndex].amount -= juicePerTap;
				for(int i = 0; i < _liquid.Length; i++) // Decreases the liquid level in the container
				{
					_liquid[i].localScale = new Vector3(_liquid[i].localScale.x, _liquid[i].localScale.y - 0.01f, _liquid[i].localScale.z);
				}
//				StartCoroutine(NetworkComm.Instance.RequestJuice((JuiceType) _thisProducerIndex, juicePerTap, OnRequestFinished));
				NetworkComm.ReleaseJuice( (JuiceType) _thisProducerIndex, juicePerTap ); //release it
			}
			else //if not, request _thisProducerIndex
			{
				if (NetworkComm.Instance.RequestJuice( (JuiceType) _thisProducerIndex )) //might not be available in the pool right now
				{
					organ.health++;
					organ.juices[_thisProducerIndex].amount += juicePerTap;
					for(int i = 0; i < _liquid.Length; i++) // Increases the liquid level in the container
					{
						_liquid[i].localScale = new Vector3(_liquid[i].localScale.x, _liquid[i].localScale.y + 0.01f, _liquid[i].localScale.z);
					}
				}
			}
		}
		else{
			//TODO: Your organ is fucking dead :(
		}
	}



}
