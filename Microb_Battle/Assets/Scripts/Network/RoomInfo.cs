using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomInfo : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text roomID;
    private void Start()
    {
        roomID.text = "ID: " + PhotonNetwork.CurrentRoom.Name;
    }
}
