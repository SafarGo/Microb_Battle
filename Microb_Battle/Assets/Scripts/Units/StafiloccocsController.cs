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


    IEnumerator Attack()
    {
        MainTowerController.HP -= _damage;
        yield return new WaitForSeconds(_attackTime);
        isAttacking = false;
        Debug.Log("Attack");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MainTower"))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Attack());

            }
        }
    }
}
