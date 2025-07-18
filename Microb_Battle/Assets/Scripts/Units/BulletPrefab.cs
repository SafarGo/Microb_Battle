using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPrefab : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public PlazmocitAttack attack;
    private void Start()
    {
        if (!gameObject.GetComponent<PhotonView>().IsMine)
        {
            gameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }
    private void Update()
    {
        if (target != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (other.GetComponent<StafiloccocsController>() != null)
            {
                other.GetComponent<StafiloccocsController>().lives -= 9 * attack.level;
                other.GetComponent<StafiloccocsController>().SyncHeals();
            }
            else if (other.GetComponent<TuberculesBacilusController>() != null)
            {
                other.GetComponent<TuberculesBacilusController>().lives -= 9 * attack.level;
                other.GetComponent<TuberculesBacilusController>().SyncHeals();
                Destroy(gameObject);
            }
            else if (other.GetComponent<Saprofit_Controller>() != null)
            {
                other.GetComponent<Saprofit_Controller>().lives -= 9 * attack.level;
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Klost"))
        {
            other.GetComponent<KlostridiyController>().lives -= 9 * attack.level;
            Destroy(gameObject);
        }
    }
}