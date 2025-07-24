using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectServerByButton : MonoBehaviourPunCallbacks
{
    public void Connect(TMPro.TMP_Text name)
    {
        PhotonNetwork.JoinRoom(name.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        Debug.Log("joined to game");
    }
}
