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
                other.GetComponent<StafiloccocsController>().lives -= 20 * attack.level;
                other.GetComponent<StafiloccocsController>().SyncHeals();
            }
            else
                other.GetComponent<TuberculesBacilusController>().lives -= 20 * attack.level;
            Destroy(gameObject);
        }
        if(other.CompareTag("Klost"))
        {
            Destroy(other.gameObject);
            GameManager.Glukoza += 2;
            GameManager.count_of_dead_enemies++;
            Destroy(gameObject);
        }
    }
}