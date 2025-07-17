using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Belok_Controller : MonoBehaviourPun
{
    public int count_of_belok;

    void Start()
    {
        GameManager.Beloks.Add(this.gameObject);
        if (photonView != null && photonView.InstantiationData != null && photonView.InstantiationData.Length > 0)
        {
            count_of_belok = (int)photonView.InstantiationData[0];
            Debug.Log("count_of_belok = " + count_of_belok);
        }
    }
}
