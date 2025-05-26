using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkStormParticles : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public Button button;

    private void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.Pause();
        ParticleSystem.Clear();
        button.onClick.AddListener(Storm);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    void Storm()
    {
        ParticleSystem.Play();
    }
}
