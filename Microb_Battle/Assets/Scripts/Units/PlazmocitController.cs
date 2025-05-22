using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlazmocitController : MonoBehaviour, IDamageable
{
    public float _attack_time = 1f;
    public GameObject _target;
    public Slider slider;
    public GameObject parent;
    void Awake()
    {
        GameManager.towers.Add(this.gameObject);
        slider.value = HP;
    }
    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
        if (HP <= 0)
        {
            Destroy(parent);
            GameManager.towers.Remove(this.gameObject);
        }
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

    void Update()
    {
    }
}
