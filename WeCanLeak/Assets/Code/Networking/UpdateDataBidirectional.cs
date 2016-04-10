using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (PhotonView))]
public class UpdateDataBidirectional : Photon.MonoBehaviour, IPunObservable {

	public int ValueToShow;
	private int t;
	private int myInt;

	public int characterID = 1;

	private bool written = false;

	void Start()
	{
		myInt = Random.Range (0, 100);
	}

	// Update is called once per frame
	void Update () {
	}

//	public void decideOwner()
//	{
//		if(gameObject.name == PhotonNetwork.player.ID) 
//	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{

		if (stream.isWriting) //whole body
		{
//			We own this player: send the others our data
			t = myInt;
			stream.SendNext(t);
			//			stream.SendNext(transform.position);
			//			stream.SendNext(transform.rotation);
		}
		else //body part
		{
			//Network player, receive data
			t = (int)stream.ReceiveNext();
			//			correctPlayerPos = (Vector3)stream.ReceiveNext();
			//			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			//Debug.LogWarning ("The value received is " + t + " ****************");
		}
	}

	
	void OnGUI()
	{
		GUI.Label (new Rect(5, 200, 100, 50), ("myInt = " + myInt));
		GUI.Label (new Rect(5, 225, 100, 50), ("sharedInt = " + t));
		
		if (GUI.Button (new Rect (5, 280, 100, 50), "take ownership"))
		{
			PhotonView photonView = PhotonView.Get(this);
			photonView.TransferOwnership (PhotonNetwork.player.ID);
		}
	}
	
}
