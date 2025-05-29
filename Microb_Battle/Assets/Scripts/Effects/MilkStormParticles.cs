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
        button.onClick.AddListener(Storm);
    }

    private void OnParticleCollision(GameObject other)
    {
            Debug.Log("Collision");
            Destroy(other.gameObject);
        
    }

    private void Update()
    {
        if(GameManager.Glukoza >= 30)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }


    void Storm()
    {
        ParticleSystem.Play();
        GameManager.AttackAllStaf();
    }
}
