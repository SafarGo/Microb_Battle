using UnityEngine;
using Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class MenuNetworkManager : MonoBehaviourPunCallbacks
{

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
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        Debug.Log("joined to game");
    }
}
