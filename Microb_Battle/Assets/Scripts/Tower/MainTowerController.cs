using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerController : MonoBehaviour, IDamageable
{
    public float HP { get; set; } = 100f;
    public AudioSource sound; 
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
        if (HP >= 75) { sound.pitch = 0.8f; }
        if (HP < 75 && HP >= 50) { sound.pitch = 1f; }
        if (HP < 50 && HP >= 30) { sound.pitch = 1.2f; }
        if(HP < 30) { sound.pitch = 1.5f; }

    }
}
