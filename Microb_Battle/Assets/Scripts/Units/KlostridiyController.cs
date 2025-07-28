using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class KlostridiyController : MonoBehaviour
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
    public PhotonView photonView;
    public AudioSource Sound;

    private void Start()
    {
        photonView =gameObject.GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

        _damage *= Enemy_Upgrade_Units.klostrydyy_attack_bonus;
        SetupTarget();
        GameManager.enemies.Add(this.gameObject);

    }

    void SetupTarget()
    {
        Wall[] walls = FindObjectsOfType<Wall>();
        if (walls.Length > 0)
        {
            _target = walls[FindNearestWalls()];
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
        Sound.Play();
        PhotonNetwork.Destroy(gameObject);
        _target.TakeDamage(_damage);
        isAttacked = true;
        object[] data = new object[] { count_of_spawn_belok };
        Debug.LogError("Клостридия ударила первый раз");
        PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
        Debug.LogError("Клостридия ударила после смерти");
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _target.gameObject.transform.position);
        if (distance < 2f && !isAttacked && _target != null)
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

    private int FindNearestWalls()
    {
        Wall[] walls = FindObjectsOfType<Wall>();
        int result = 0;
        float startdist = 10 * 10 ^ 5;
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i] != null)
            {
                float dist = Vector3.Distance(walls[i].transform.position, gameObject.transform.position);
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