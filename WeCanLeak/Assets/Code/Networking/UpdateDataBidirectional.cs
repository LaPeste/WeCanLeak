using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (PhotonView))]
public class UpdateDataBidirectional : Photon.MonoBehaviour, IPunObservable {

	public int ValueToShow;
	private int t;

	void Start()
	{
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) //whole body
		{
//			We own this player: send the others our data
			stream.SendNext(1);
			//			stream.SendNext(transform.position);
			//			stream.SendNext(transform.rotation);
			Debug.LogWarning ("whole body sending");
		}
		else //body part
		{
			//Network player, receive data
			t = (int)stream.ReceiveNext();
			t++;
			//			correctPlayerPos = (Vector3)stream.ReceiveNext();
			//			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			Debug.LogWarning ("The value received is " + t + " ****************");
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect(5, 200, 50, 50), ("t = " + t));
	}

}
