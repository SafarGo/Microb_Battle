using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk_collision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(other);
    }
}
