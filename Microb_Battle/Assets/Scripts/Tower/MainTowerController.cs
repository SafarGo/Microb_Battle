using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerController : MonoBehaviour, IDamageable
{
    public float HP { get; set; } = 100f;

    void Awake()
    {
        GameManager.towers.Add(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
    }

    void Update()
    {
        if(HP<=0) {Destroy(this.gameObject); GameManager.towers.Remove(this.gameObject); }
    }
}
