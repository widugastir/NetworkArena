using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;


public class LobbyConnect : MonoBehaviourPunCallbacks
{
    public void Start()
    {
	    PhotonNetwork.NickName = "Player" + Random.Range(0, 5000);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
    }


    public void CreatedRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public void JoinToRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}
    
	public override void OnJoinedRoom()
    {
	    PhotonNetwork.LoadLevel("Game");
    }
    
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Left");
    }

    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.Log("Join");
    }
}

