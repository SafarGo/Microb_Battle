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
    public AudioSource attackSound;
    float _new_speed;

    private void Start()
    {
        int index = UnityEngine.Random.Range(0, GameManager.towers.Count);
        agent.SetDestination(GameManager.towers[index].transform.position);
        GameManager.enemies.Add(this.gameObject);
        _new_speed = agent.speed * 0.75f;
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
            if(other.CompareTag("Ketogenez") && GameManager.isKetognez1)
            {
                
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

    private void Update()
    {
        _slider.value = lives;
        if(lives<=0)
        {
            GameManager.Glukoza += 5;
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
