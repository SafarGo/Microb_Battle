using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class KlostridiyController : MonoBehaviourPun
{
    [SerializeField] float _damage;
    [SerializeField] float _speed;
    [SerializeField] private Wall _target;
    [SerializeField] private NavMeshAgent _agent;
    public int count_of_spawn_belok;
    bool isAttacked = false;
    public ParticleSystem system;
    public float lives = 30;
    public float price;

    private void Awake()
    {
        _damage *= Enemy_Upgrade_Units.klostrydyy_attack_bonus;
        SetupTarget();
        GameManager.enemies.Add(this.gameObject);
    }

    private void Start()
    {
        if (!photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

    }

    void SetupTarget()
    {
        Wall[] walls = FindObjectsOfType<Wall>();
        if (walls.Length > 0)
        {
            int index = Random.Range(0, walls.Length);
            _target = walls[index];
            _agent.SetDestination(_target.transform.position);
        }
        else
        {
            GameManager.enemies.Remove(this.gameObject);
            PhotonNetwork.Destroy(gameObject);
        }
    }

    void Attack()
    {
        _target.TakeDamage(_damage);
        isAttacked = true;
        object[] data = new object[] { count_of_spawn_belok };
        PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
        PhotonNetwork.Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.1f && !isAttacked && _target != null)
        {
            Attack();
            Instantiate(system, transform.position, system.transform.rotation);
        }
        if (_target == null)
        {
            SetupTarget();
        }
        if (lives <= 0)
        {
            GameManager.Glukoza += 3;
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ketogenez"))
        {
            lives += lives * Enemy_Upgrade_Units.AttackUnits_HPBonus;
            _agent.speed *= Enemy_Upgrade_Units.AttackUnits_speedBonus;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ketogenez"))
        {
            _agent.speed /= Enemy_Upgrade_Units.AttackUnits_speedBonus;
        }
    }
}