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
    public float lives = 100f;
    public NavMeshAgent agent;
    private bool isAttacking = false;

    private void Start()
    {
        int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
        agent.SetDestination(GameManager.towers[index].transform.position);

    }


    IEnumerator Attack(GameObject obj)
    {
        IDamageable dama = obj.GetComponent<IDamageable>();
        if (dama != null)
        {
            dama.TakeDamage(_damage);
        }
        else
        {
            Debug.LogError("������ �� ��������� IDamageable: " + obj.name);
        }
        yield return new WaitForSeconds(_attackTime);
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
    }

    private void Update()
    {
        _slider.value = lives;
        if(lives<=0)
        {
            GameManager.Glukoza += 10;
            GameManager.count_of_dead_enemies++;
            Destroy(this.gameObject);
            
        }
        if(!agent.hasPath)
        {
            int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
            agent.SetDestination(GameManager.towers[index].transform.position);
        }
    }
}
