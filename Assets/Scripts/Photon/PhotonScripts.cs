using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class PhotonScripts : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//Server'a ba�lan�yor
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Server'a ba�land�");
        PhotonNetwork.JoinLobby();//lobiye giri� yapmam�z� sa�l�yor

        base.OnConnectedToMaster();

    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("GameRoom", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);

        base.OnJoinedLobby();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya Ba�lan�ld�");
        GameObject newPlayer = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);

        newPlayer.GetComponent<PhotonView>().Owner.NickName = Random.Range(1, 50) + " (Misafir)";

        base.OnJoinedRoom();
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden ��k�ld�");
        base.OnLeftLobby();
    }
    public override void OnLeftRoom()
    {
        Debug.Log("Odadan ��k�ld�");
        base.OnLeftLobby();
    }



}
