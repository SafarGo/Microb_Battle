using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

public class SinFog_Controller : MonoBehaviour
{
    public int Damage;
    public float Life_Time;

    private void Update()
    {
        Life_Time -= Time.deltaTime;
        if(Life_Time < 0 )
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<StafiloccocsController>() != null)
            {
                other.gameObject.GetComponent<StafiloccocsController>().lives -= Damage;
            }
            else if (other.gameObject.GetComponent<TuberculesBacilusController>() != null)
            {
                other.gameObject.GetComponent<TuberculesBacilusController>().lives -= Damage;
            }
            else if (other.gameObject.GetComponent<KlostridiyController>() != null)
            {
                other.gameObject.GetComponent<KlostridiyController>().lives -= Damage;
            }
            else if (other.gameObject.GetComponent<Saprofit_Controller>() != null)
            {
                other.gameObject.GetComponent<Saprofit_Controller>().lives -= Damage;
            }
        }
    }
}
