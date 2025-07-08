using UnityEngine;
using Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class MenuNetworkManager : MonoBehaviourPunCallbacks
{
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
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
