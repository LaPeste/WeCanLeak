using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChooseOrganUI : MonoBehaviour {

	public List<Button> organButtons;

	public GameObject organUIPrefab;
	
	private void OnEnable()
	{
		organButtons [0].onClick.AddListener (OnOrgan1Click);
		organButtons [1].onClick.AddListener (OnOrgan2Click);
		organButtons [2].onClick.AddListener (OnOrgan3Click);
		organButtons [3].onClick.AddListener (OnOrgan4Click);
	}
	
	private void OnDisable()
	{
		organButtons [0].onClick.RemoveListener (OnOrgan1Click);
		organButtons [1].onClick.RemoveListener (OnOrgan2Click);
		organButtons [2].onClick.RemoveListener (OnOrgan3Click);
		organButtons [3].onClick.RemoveListener (OnOrgan4Click);
	}

	private void OnOrgan1Click()
	{
		OrganUI organui = Instantiate <GameObject>(organUIPrefab).GetComponent<OrganUI>();
		organui.transform.parent = transform.parent;
		organui.Initialize (0);
		Destroy (gameObject);
	}

	private void OnOrgan2Click()
	{
		OrganUI organui = Instantiate <GameObject>(organUIPrefab).GetComponent<OrganUI>();
		organui.transform.parent = transform.parent;
		organui.Initialize (1);
		Destroy (gameObject);
	}

	private void OnOrgan3Click()
	{
		OrganUI organui = Instantiate <GameObject>(organUIPrefab).GetComponent<OrganUI>();
		organui.transform.parent = transform.parent;
		organui.Initialize (2);
		Destroy (gameObject);
	}

	private void OnOrgan4Click()
	{
		OrganUI organui = Instantiate <GameObject>(organUIPrefab).GetComponent<OrganUI>();
		organui.transform.parent = transform.parent;
		organui.Initialize (3);
		Destroy (gameObject);
	}
}
