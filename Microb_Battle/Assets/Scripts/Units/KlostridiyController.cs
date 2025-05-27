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
    public AudioSource source;

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
            int index = Random.Range(0, walls.walls.Count);
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
        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if(_agent.remainingDistance <0.5f && !isAttacked)
        {
            Instantiate(source);
            Attack();
            Instantiate(system, transform.position, system.transform.rotation);
            
        }
        if(_target == null)
        {
            SetupTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Storm"))
        {
            Destroy(gameObject);
        }
    }
}
