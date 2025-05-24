using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStormParticles : MonoBehaviour
{
    public Mesh newMesh; 
    private ParticleSystemRenderer psRenderer;

    private void Start()
    {
        psRenderer = GetComponent<ParticleSystemRenderer>();
    }
}
