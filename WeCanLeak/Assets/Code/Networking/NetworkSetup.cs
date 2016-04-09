using UnityEngine;
using System.Collections;

public class NetworkSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("v4.2");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
