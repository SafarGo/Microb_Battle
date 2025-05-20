using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class StafiloccocsController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;
    public NavMeshAgent agent;
    private bool isAttacking = false;

    private void Start()
    {
        agent.SetDestination(_target.position);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainTower"))
        {
            Debug.Log("!");
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Attack());
                
            }
        }
    }
    

    IEnumerator Attack()
    {
        MainTowerController.HP -= _damage;
        yield return new WaitForSeconds(_attackTime);
        isAttacking = false;
    }

}
