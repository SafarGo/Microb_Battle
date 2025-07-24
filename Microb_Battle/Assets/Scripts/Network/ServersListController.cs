using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun.Demo.Cockpit;
using Photon.Pun.Demo.Asteroids;
using Photon.Pun;

public class ServersListController : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    // Start is called before the first frame update
    [SerializeField] GameObject buttonToLaunchServer;
    [SerializeField] Transform grid;
    void Start()
    {
        for (int i = 0; i < PhotonNetwork.CountOfRooms; i++)
        {
            Instantiate(buttonToLaunchServer, transform.position, Quaternion.identity);
            //PhotonNetwork.GetCustomRoomList
        }

    }
}
