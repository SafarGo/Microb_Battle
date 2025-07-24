using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class DamageFog : MonoBehaviourPunCallbacks
{
    //[SerializeField] private Transform _target;
    [SerializeField] private float fogTime = 15;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;
    private bool isAttacking = false;
    public AudioSource attackSound;
    private PhotonView photonView;

    protected virtual void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        _attackTime *= Enemy_Upgrade_Units.streptoFogLifetimeBonus;
        if (!photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

        GameManager.enemies.Add(this.gameObject);
        Destroy(gameObject, fogTime * Enemy_Upgrade_Units.streptoFogLifetimeBonus);
    }

    

    IEnumerator Attack(GameObject obj)
    {
        IDamageable dama = obj.GetComponent<IDamageable>();
        if (dama != null)
        {
            attackSound.volume = GameManager.instance.volume.value;
            attackSound.Play();
            dama.TakeDamage(_damage);
        }
        else
        {
            Debug.LogError("Объект не реализует IDamageable: " + obj.name);
        }
        yield return new WaitForSeconds(_attackTime);
        isAttacking = false;
        Debug.Log("Attack");
    }
    private void OnTriggerStay(Collider other)
    {
        if(!PhotonNetwork.IsMasterClient) return;

        if (!isAttacking && other.CompareTag("Unit"))
        {
            isAttacking = true;
            StartCoroutine(Attack(other.gameObject));
        }
    }
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Storm"))
    //    {
    //        GameManager.count_of_dead_enemies++;
    //        GameManager.enemies.Remove(this.gameObject);
    //        Destroy(this.gameObject);
    //    }
    //}
}
