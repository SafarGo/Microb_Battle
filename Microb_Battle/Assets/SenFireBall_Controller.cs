using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenFireBall_Controller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<StafiloccocsController>() != null)
            {
                other.GetComponent<StafiloccocsController>().lives -= 20;
                other.GetComponent<StafiloccocsController>().SyncHeals();
                Destroy(gameObject);
            }
            else if (other.GetComponent<TuberculesBacilusController>() != null)
            {
                other.GetComponent<TuberculesBacilusController>().lives -= 20;
                other.GetComponent<TuberculesBacilusController>().SyncHeals();
                Destroy(gameObject);
            }
            else if(other.GetComponent<Saprofit_Controller>() != null)
            {
                other.GetComponent<Saprofit_Controller>().lives -= 20;
                Destroy(gameObject);
            }
                

        }
        if (other.CompareTag("Klost"))
        {
            other.GetComponent<KlostridiyController>().lives -= 20;
            Destroy(gameObject);
        }
        
    }
}
