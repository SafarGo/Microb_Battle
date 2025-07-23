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
    [SerializeField] private float AtkKof;
    [SerializeField] private Slider _slider;
    //[SerializeField] private PhotonView photonView;
    public float lives = 100f;
    public int EnemyCost = 100;
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
        if (GameManager.Count_of_belok >= EnemyCost)
            GameManager.Count_of_belok -= EnemyCost;

            agent.speed *= GameManager.attakUnitsSpeedBonus;
        lives *= GameManager.attakUnitsHPBonus;
        _slider.maxValue = _slider.value = lives;
        GameManager.enemies.Add(this.gameObject);
        SetDestination();

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

    IEnumerator PlaochkaAttack(GameObject obj)
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
        _attackTime *= AtkKof;
        isAttacking = false;
        Debug.Log("Attack");
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isAttacking && other.CompareTag("Unit"))
        { 
            isAttacking = true;

            if (AtkKof == 0)
            {
                StartCoroutine(Attack(other.gameObject));
            }
            else 
            {
                StartCoroutine(PlaochkaAttack(other.gameObject));
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Storm"))
        {
            GameManager.count_of_dead_enemies++;
            GameManager.enemies.Remove(this.gameObject);
        }
    }

    private void LateUpdate()
    {
            //if (gameObject.GetComponent<PhotonView>().IsMine)
            //    Debug.LogError("Атакующий ли игрок - ");
            CheckState();
    }

    protected void SetDestination()
    {
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
        _slider.value = lives;
        if (lives <= 0 && !PhotonNetwork.IsMasterClient)
        {
            AtackUnitsBehaviour.AUB.Death(gameObject,enemyType);
            PhotonNetwork.Destroy(gameObject);
        }
        if (!agent.hasPath || target == null)
        {
            SetDestination();
        }
    }
    public void SyncHeals()
    {
        photonView.RPC("UpdateHealth", RpcTarget.Others, lives);
    }
    [PunRPC]
    public void UpdateHealth(float newHealth)
    {
        lives = newHealth;
        _slider.value = lives;
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
