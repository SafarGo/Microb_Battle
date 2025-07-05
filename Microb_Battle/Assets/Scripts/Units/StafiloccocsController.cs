using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StafiloccocsController : MonoBehaviour
{
    //[SerializeField] private Transform _target;
    [SerializeField] private string enemyType;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    public float lives = 100f;
    public NavMeshAgent agent;
    private bool isAttacking = false;
    public AudioSource attackSound;

    protected virtual void Start()
    {
        int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
        GameManager.enemies.Add(this.gameObject);

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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Storm"))
        {
            GameManager.count_of_dead_enemies++;
            GameManager.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
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
            AtackUnitsBehaviour.AUB.Death(gameObject,enemyType);
        }
        if (!agent.hasPath)
        {
            SetDestination();
        }
        
    }



}
