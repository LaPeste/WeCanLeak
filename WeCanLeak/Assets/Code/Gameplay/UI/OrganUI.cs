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

	int producerindex;

	public void Initialize(int selectedOrgan)
	{
		this.selectedOrgan = selectedOrgan;
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
	
	private void OnJuice1Clicked()
	{
		if (producerindex == phlegmIndex) //if this organ produces phlegm...
		{
			organ.juices[phlegmIndex].amount -= juicePerTap;
			NetworkComm.ReleaseJuice(JuiceType.Phlegm); //release it
		}
		else //if not, request phlegm
		{
			if (NetworkComm.RequestJuice(JuiceType.Phlegm)) //might not be available in the pool right now
				organ.juices[phlegmIndex].amount += juicePerTap;
		}
	}

	private void OnJuice2Clicked()
	{
		if (producerindex == yellowIndex)
		{
			organ.juices[yellowIndex].amount -= juicePerTap;
			NetworkComm.ReleaseJuice(JuiceType.YellowBile);
		} 
		else
		{
			if (NetworkComm.RequestJuice(JuiceType.YellowBile))
				organ.juices[yellowIndex].amount += juicePerTap;
		}
	}

	private void OnJuice3Clicked()
	{
		if (producerindex == blackIndex)
		{
			organ.juices[blackIndex].amount -= juicePerTap;
			NetworkComm.ReleaseJuice(JuiceType.BlackBile);
		} 
		else
		{
			if (NetworkComm.RequestJuice(JuiceType.BlackBile))
				organ.juices[blackIndex].amount += juicePerTap;
		}
	}

	private void OnJuice4Clicked()
	{
		if (producerindex == bloodIndex)
		{
			organ.juices[bloodIndex].amount -= juicePerTap;
			NetworkComm.ReleaseJuice(JuiceType.Blood);
		} 
		else
		{
			if (NetworkComm.RequestJuice(JuiceType.Blood))
				organ.juices[bloodIndex].amount += juicePerTap;
		}
	}
}
