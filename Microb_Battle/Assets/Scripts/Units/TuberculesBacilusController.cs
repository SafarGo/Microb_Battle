using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Photon.Pun;
using JetBrains.Annotations;

public class TuberculesBacilusController : MonoBehaviour
{
    //[SerializeField] private Transform _target;
    [SerializeField] private string enemyType;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _attackTimeKof = 0.085f;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    public float lives = 100f;
    public NavMeshAgent agent;
    private bool isAttacking = false;
    public AudioSource attackSound;
    public PhotonView photonView;
    public float price;

    protected virtual void Start()
    {
        agent.speed *= GameManager.attakUnitsSpeedBonus;
        lives *= GameManager.attakUnitsHPBonus;
        _slider.maxValue = _slider.value = lives;
        //int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
        GameManager.enemies.Add(this.gameObject);
        GameManager.Count_of_belok -= price;
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
        _attackTime *= _attackTimeKof ;
        isAttacking = false;
        Debug.Log("Attack");
    }
    private void OnTriggerStay(Collider other)
    {
        if (!isAttacking && other.CompareTag("Unit"))
        {
            isAttacking = true;
            StartCoroutine(Attack(other.gameObject));
        }
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti1)
        {
            lives *= 1.05f;
        }
        if(other.CompareTag("StrepFog"))
        {
            if(GameManager.isUpgr4)
            {
                _damage *= 1.1f;
            }
        }
        if (other.gameObject.CompareTag("Ketogenez") && GameManager.isAnti2)
        {
            agent.speed *= 1.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StrepFog"))
        {
            if (GameManager.isUpgr4)
            {
                _damage /= 1.1f;
            }
        }
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
        if (other.gameObject.CompareTag("Storm"))
        {
            GameManager.count_of_dead_enemies++;
            GameManager.enemies.Remove(this.gameObject);
           PhotonNetwork.Destroy(this.gameObject);
        }
        

    }

    private void LateUpdate()
    {
        CheckState();
    }

    protected void SetDestination()
    {
        if (!agent.hasPath)
        {
            int destination_index = UnityEngine.Random.Range(0, GameManager.towers.Count);
            if (GameManager.towers[destination_index] != null)
            {
                agent.SetDestination(GameManager.towers[destination_index].transform.position);
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
        if (lives <= 0)
        {
            AtackUnitsBehaviour.AUB.Death(gameObject, "Stafilococ");
            object[] data = new object[] { 10 };
            PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
        }
        if (!agent.hasPath)
        {
            SetDestination();
        }

    }

    public void SyncHeals()
    {
        photonView.RPC(nameof(UpdateHealthB), RpcTarget.Others, lives);
    }
    [PunRPC]
    public void UpdateHealthB(float newHealth)
    {
        lives = newHealth;
        _slider.value = lives;
    }



}
