using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Realtime;

public class isMine : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private CameraController controller;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            controller.enabled = false;
        }
    }
}
