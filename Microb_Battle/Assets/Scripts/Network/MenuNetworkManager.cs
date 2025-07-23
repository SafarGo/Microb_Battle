using UnityEngine;
using Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

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
}
