using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Realtime;

public class isMine : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _photonView;

    void Awake()
    {
       // _photonView = GetComponent<PhotonView>();
       // if (!_photonView.IsMine)
       // {
       //     gameObject.GetComponent<CameraController>().enabled = false;
       // }
    }
}
