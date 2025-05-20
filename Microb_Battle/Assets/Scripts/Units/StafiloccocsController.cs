using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StafiloccocsController : MonoBehaviour
{
    //[SerializeField] private Transform _target;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    public static  float lives = 100f;
    public NavMeshAgent agent;
    private bool isAttacking = false;

    private void Start()
    {
        agent.SetDestination(GameObject.Find("Main_Tower_Prefab").transform.position);

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

    private void Update()
    {
        _slider.value = lives;
        if(lives<=0)
        {
            Destroy(this.gameObject);
            GameManager.Glukoza += 10;
        }
    }
}
