using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StafiloccocsController : MonoBehaviourPunCallbacks
{
    //[SerializeField] private Transform _target;
    [SerializeField] private string enemyType;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    //[SerializeField] private PhotonView photonView;
    public float lives = 100f;
    public NavMeshAgent agent;
    private bool isAttacking = false;
    public AudioSource attackSound;
    private GameObject target;
    //[SerializeField]private bool isAtacPlayer = false;
    protected virtual void Start()
    {
            if (!photonView.IsMine)
            {
                photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
            }
        //if(gameObject.GetComponent<PhotonView>().Owner != PhotonNetwork.MasterClient)
        //    if(gameObject.GetComponent<PhotonView>().IsMine)
        //        isAtacPlayer = true;
        //photonView = gameObject.GetComponent<PhotonView>();

            agent.speed *= GameManager.attakUnitsSpeedBonus;
        lives *= GameManager.attakUnitsHPBonus;
        _slider.maxValue = _slider.value = lives;
        //int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
        GameManager.enemies.Add(this.gameObject);
        //if (!isAtacPlayer) return;
        SetDestination();

        //if (GetComponent<PhotonView>().Owner != PhotonNetwork.MasterClient)
        //    if (GetComponent<PhotonView>().IsMine)
        //        Destroy(this);

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
        //if (GameManager.isAttacker) { return; }
        //if (!isAtacPlayer) return;
        if (!isAttacking && other.CompareTag("Unit"))
            { 
                isAttacking = true;
                StartCoroutine(Attack(other.gameObject));
            }
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti1)
        {
            lives *= 1.05f;
        }
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti2)
        {
            agent.speed *= 1.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti1)
        {
            lives /= 1.05f;
        }
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti2)
        {
            agent.speed /= 1.1f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (!isAtacPlayer) return;
        if (other.gameObject.CompareTag("Storm"))
        {
            GameManager.count_of_dead_enemies++;
            GameManager.enemies.Remove(this.gameObject);
            //if(photonView.Owner == PhotonNetwork.MasterClient)
            //    Destroy(this.gameObject);
        }
        
    }

    private void LateUpdate()
    {
            if (gameObject.GetComponent<PhotonView>().IsMine)
                Debug.LogError("Атакующий ли игрок - ");
            ////if (!isAtacPlayer) return;
            CheckState();
    }

    protected void SetDestination()
    {
        //if (!isAtacPlayer) return;
        if (!agent.hasPath)
        {
            int destination_index = FindNearest();
            if (GameManager.towers[destination_index] != null)
            {
                target = GameManager.towers[destination_index];
                agent.SetDestination(target.transform.position);
            }
            else
            {
                SetDestination();
            }
        }
    }

    private void CheckState()
    {

        //if (!isAtacPlayer) return;
        _slider.value = lives;
        if (lives <= 0)
        {
            AtackUnitsBehaviour.AUB.Death(gameObject,enemyType);
            object[] data = new object[] { 3 };
            PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
        }
        if (!agent.hasPath || target == null)
        {
            SetDestination();
        }
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if(stream.IsWriting)
    //    {
    //        stream.SendNext(lives);
    //    }
    //    else
    //    {
    //        lives = (float)(stream.ReceiveNext());
    //    }
    //}
    public void SyncHeals()
    {
        photonView.RPC("UpdateHealth", RpcTarget.Others, lives);
    }
    [PunRPC]
    public void UpdateHealth(float newHealth)
    {
        lives = newHealth;
        _slider.value = lives;
        //if (lives <= 0)
        //{
        //    AtackUnitsBehaviour.AUB.Death(gameObject, enemyType);
        //}
    }

    private int FindNearest()
    {
        int result = 0;
        float startdist = 10 * 10^5;
        for (int i = 0; i < GameManager.towers.Count; i++)
        {
            if(GameManager.towers[i]!=null)
            {
                float dist = Vector3.Distance(GameManager.towers[i].transform.position, gameObject.transform.position);
                if (dist < startdist)
                {
                    startdist = dist;
                    result = i;
                }
            }
        }
        return result;
    }


}
