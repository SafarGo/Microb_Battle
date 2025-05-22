using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazmocitController : MonoBehaviour, IDamageable
{
    public float _attack_time = 1f;
    public GameObject _target;
    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
        if(HP<=0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_target == null)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_target == null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
        }
    }

}
