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
    [SerializeField] private GameObject _camera;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            _camera.SetActive(false);
            controller.enabled = false;
        }
    }
}
