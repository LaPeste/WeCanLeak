using UnityEngine;
using System.Collections;

public class InputTestController : MonoBehaviour {

	OrganUI organui;
	BodyController bodyController;

	void Start()
	{
		FindControllers ();
	}

	void FindControllers()
	{
		organui = FindObjectOfType<OrganUI> ();
		bodyController = FindObjectOfType<BodyController> ();
	}

	// Update is called once per frame
	void Update () {
		if(organui == null && bodyController == null)
			FindControllers ();

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			// release liver
			if(organui)
				organui.OnJuice1Clicked();
			if(bodyController)
				bodyController.OrganReleaseJuice((OrganType)0, (JuiceType)0, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			// release spleen
			if(organui)
				organui.OnJuice2Clicked();
			if(bodyController)
				bodyController.OrganReleaseJuice((OrganType)1, (JuiceType)1, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			// release bladder
			if(organui)
				organui.OnJuice3Clicked();
			if(bodyController)
				bodyController.OrganReleaseJuice((OrganType)2, (JuiceType)2, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			// release lungs
			if(organui)
				organui.OnJuice4Clicked();
			if(bodyController)
				bodyController.OrganReleaseJuice((OrganType)3, (JuiceType)3, 10);
		}

		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			// request liver
			if(bodyController)
				bodyController.OrganRequestJuice((OrganType)0, (JuiceType)0, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			// request spleen
			if(bodyController)
				bodyController.OrganRequestJuice((OrganType)1, (JuiceType)1, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			// request bladder
			if(bodyController)
				bodyController.OrganRequestJuice((OrganType)2, (JuiceType)2, 10);
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			// request lungs
			if(bodyController)
				bodyController.OrganRequestJuice((OrganType)3, (JuiceType)3, 10);
		}
	}
}
