using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class PlayerSideController : MonoBehaviour
{
    public bool isAtaker;
    public static PlayerSideController instance;
    private void Start()
    {
        if(PhotonNetwork.CountOfPlayers == 1)
        {
            isAtaker = false;
        }
        else
        {
            isAtaker = true;
        }
    }
}
