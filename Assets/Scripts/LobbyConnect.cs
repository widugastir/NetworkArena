using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;


public class LobbyConnect : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(-999f, 999f);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.JoinRoom("someRoom");
        Debug.Log("OnConnectedToMaster() was called by PUN.");



        
        //PhotonNetwork.JoinOrCreateRoom(nameEveryFriendKnows, roomOptions, TypedLobby.Default);
    }


    public void CreatedRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public void JoinToRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    public override void OnLeftRoom()
    {
        
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

