using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlueStick : MonoBehaviour
{

    public void Create_BlueStick()
    {
        PhotonNetwork.Instantiate("Palochka", new Vector3(0,0,0), Quaternion.identity);
    }
}
