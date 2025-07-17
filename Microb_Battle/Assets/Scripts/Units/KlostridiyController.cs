using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KlostridiyController : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _speed;
    [SerializeField] private Wall _target;
    [SerializeField] private NavMeshAgent _agent;
    bool isAttacked = false;
    public ParticleSystem system;
    public int lives = 10;

    private void Awake()
    {
        SetupTarget();
        GameManager.enemies.Add(this.gameObject);
    }

    void SetupTarget()
    {
        var walls = GameObject.Find("WallsBuilder").GetComponent<BuildWalls>();
        if (walls.walls.Count != 0)
        {
            int index = Random.Range(0, walls.walls.Count-1);
            _target = walls.GetComponent<BuildWalls>().walls[index];
            _agent.SetDestination(_target.transform.position);
        }
        else
        {
            GameManager.enemies.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        
        _target.TakeDamage(_damage);
        Destroy(this.gameObject);
        isAttacked = true;
        object[] data = new object[] { 4 };
        PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);

        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if(_agent.remainingDistance <0.1f && !isAttacked && _target !=null)
        {
            
            Attack();
            Instantiate(system, transform.position, system.transform.rotation);
            
        }
        if(_target == null)
        {
            SetupTarget();
        }
    }

}
