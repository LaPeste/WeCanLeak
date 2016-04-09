using UnityEngine;
using System.Collections;

// sent from organ to body when requesting juice
public class OrganJuiceRequestData
{
	public Juice juiceRequestedData;
}

// sent from body to organ as a response to the juice request
public class BodyJuiceResponseData
{
	public Juice juiceReceivedData;
}

// sent from organ to body when releasing some juice
public class OrganJuiceReleaseData
{
	public Juice juiceReleasedData;
}

// sent from organ to body at regular intervals to give information about organ
public class OrganInformationData
{
	public Organ organData;
}