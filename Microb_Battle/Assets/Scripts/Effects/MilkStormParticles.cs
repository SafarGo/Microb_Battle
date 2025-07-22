using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkStormParticles : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        Destroy(other.gameObject);
    }
}
