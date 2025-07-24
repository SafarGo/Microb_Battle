using Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNetworkManager : MonoBehaviourPunCallbacks
{
    private string roomName;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.CleanupCacheOnLeave = true;
        roomOptions.EmptyRoomTtl = 0;
        PhotonNetwork.CreateRoom((PhotonNetwork.CountOfRooms + 1).ToString(), roomOptions, TypedLobby.Default);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        Debug.Log("joined to game");
    }
    public void SetRoomName(TMP_InputField input)
    {
        roomName = (input.text).ToString();
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {

        foreach (Photon.Realtime.RoomInfo game in roomList)
        {
            Debug.Log(game.Name);
            //Instantiate(buttonToLaunchServer, transform.position, Quaternion.identity);
            //buttonToLaunchServer.transform.Find("RoomID").GetComponent<TMPro.TMP_Text>().text = game.Name;
        }

    }
}
