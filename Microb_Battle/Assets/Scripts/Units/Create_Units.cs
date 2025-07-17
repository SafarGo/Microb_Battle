using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Create_Units : MonoBehaviour
{
    public void Create_SennayaPalochka(Transform position)
    {
        PhotonNetwork.Instantiate("Sennayapalochka", position.position, Quaternion.identity, 0);
    }
}
