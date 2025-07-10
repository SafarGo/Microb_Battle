using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerCanvasController : MonoBehaviour
{
    [SerializeField] private PhotonView photonView; 
    private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.Owner != PhotonNetwork.MasterClient)
        {
            if(photonView.IsMine)
                isActive = false;
        }
    }
    private void Update()
    {
        gameObject.SetActive(isActive);
        Debug.Log(isActive);
    }
}
