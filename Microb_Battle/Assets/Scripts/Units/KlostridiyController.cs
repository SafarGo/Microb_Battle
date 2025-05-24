using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        SetupTarget();
    }

    void SetupTarget()
    {
        var walls = GameObject.Find("WallsBuilder").GetComponent<BuildWalls>();
        if (walls.walls.Count != 0)
        {
            int index = Random.Range(0, walls.walls.Count);
            _target = walls.GetComponent<BuildWalls>().walls[index];
            _agent.SetDestination(_target.transform.position);
        }
    }

    void Attack()
    {
        _target.TakeDamage(_damage);
        Destroy(this.gameObject);
        isAttacked = true;
        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if(_agent.remainingDistance <0.5f && !isAttacked)
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
