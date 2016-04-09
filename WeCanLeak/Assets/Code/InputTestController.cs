using UnityEngine;
using System.Collections;

public class InputTestController : MonoBehaviour {

	OrganUI organui;
	BodyController bodyController;

	void Start()
	{
		organui = FindObjectOfType<OrganUI> ();
		bodyController = FindObjectOfType<BodyController> ();
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			// release liver
			//if(organui)
			//	organui.
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			// release spleen
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			// release bladder
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			// release lungs
		}

		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			// request liver
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			// request spleen
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			// request bladder
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			// request lungs
		}
	}
}
