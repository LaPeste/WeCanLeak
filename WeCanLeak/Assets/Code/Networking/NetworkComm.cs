using UnityEngine;
using System.Collections;
using System;
using Photon;

public class NetworkComm : Photon.MonoBehaviour
{
//	public static event EventHandler OnResponseToRequest;
	private static PhotonView photonView;

	public static NetworkComm Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject().AddComponent<NetworkComm>();
				photonView = new GameObject().AddComponent<PhotonView>();
			}
			return instance;
		}
	}

	private static NetworkComm instance;

	private NetworkComm() {	}

	public IEnumerator RequestJuice (JuiceType juiceType, int amountToRequest, Action<int> onFinished)
	{
		int receivedResources = -1;
//		PhotonView photonView = PhotonView.Get(this);
		Debug.LogWarning ("Player ID " + PhotonNetwork.player.ID);
		photonView.RPC ("ReleaseAndUpdateFromPool", PhotonTargets.All, juiceType, amountToRequest);
		while(receivedResources == -1)
		{
			yield return null;
		}

		if (onFinished != null)
			onFinished (receivedResources);
	}

	public static void ReleaseJuice (JuiceType juiceType, int amountToRequest)
	{
//		var juiceToSend = new OrganJuiceReleaseData{juiceReleasedData = new Juice{type = juiceType, amount = amountToRequest}};
//		photonView.RPC ("methodInThePool", PhotonTargets.All, "something");
	}
}
