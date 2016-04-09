using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdateDataBidirectional : Photon.PunBehaviour, IPunObservable {

	Test t;
	public int ValueToShow;

	void Start()
	{
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{

		Debug.LogWarning ("whole body sending");
		if (stream.isWriting) //whole body
		{
//			We own this player: send the others our data
			stream.SendNext((int)t.Value1);
			//			stream.SendNext(transform.position);
			//			stream.SendNext(transform.rotation);
			Debug.LogWarning ("whole body sending");
		}
		else //body part
		{
			//Network player, receive data
			t.Value1 = (int)stream.ReceiveNext();
			//			correctPlayerPos = (Vector3)stream.ReceiveNext();
			//			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			Debug.LogWarning ("body part receiving");
		}
	}



}
