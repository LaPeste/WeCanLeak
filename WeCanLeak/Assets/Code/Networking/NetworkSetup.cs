using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon;

public class NetworkSetup : Photon.PunBehaviour {

//	public List<Component> ListToAdd;
	// Use this for initialization

	public UpdateDataBidirectional CommunicationScript
	{
		get
		{
			if(communicationScript != null)
			{
				return communicationScript;
			}
			else
			{
				return null;
			}
		}
	}

	private UpdateDataBidirectional communicationScript;

	void Start ()
	{
		if (PhotonNetwork.connected || PhotonNetwork.connecting)
		{
			PhotonNetwork.Disconnect();
		}
		communicationScript = gameObject.GetComponent<UpdateDataBidirectional>();
		PhotonNetwork.ConnectUsingSettings("v1.0");

//		foreach(Component c in ListToAdd)
//		{
		Component t = gameObject.GetComponent<UpdateDataBidirectional> ();
		//photonView.ObservedComponents.Add (t);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.Friends != null && PhotonNetwork.Friends.Count > 0)
		{
			foreach(FriendInfo info in PhotonNetwork.Friends)
			{
				Debug.Log(info.Name);
			}
		}
	}

	public override void OnConnectedToMaster ()
	{
		base.OnConnectedToMaster ();
		Debug.Log ("Connected to master!");	
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom("defaultRoom", roomOptions, TypedLobby.Default);
	}

	public override void OnJoinedLobby()
	{
		base.OnJoinedLobby ();
		Debug.Log ("Lobby joined!");
	}
	 
	public override void OnPhotonInstantiate (PhotonMessageInfo info)
	{
		base.OnPhotonInstantiate (info);
		Debug.Log ("Photon instantiated!");
	}

	public override void OnPhotonPlayerConnected (PhotonPlayer newPlayer)
	{
		base.OnPhotonPlayerConnected (newPlayer);
		Debug.Log ("Client connected to server!");
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		foreach (RoomInfo game in PhotonNetwork.GetRoomList())
		{
			GUILayout.Label(game.name + " " + game.playerCount + "/" + game.maxPlayers);
		} 
		GUILayout.Label("Player count = " + PhotonNetwork.countOfPlayers);
		GUILayout.Label("Rooms count = " + PhotonNetwork.countOfRooms);
		GUILayout.Label("Player count in room = " + PhotonNetwork.countOfPlayersInRooms);
		GUILayout.Label("Player count on Master = " + PhotonNetwork.countOfPlayersOnMaster	);
	}
}
