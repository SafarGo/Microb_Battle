using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStafilococs : MonoBehaviour
{
    public GameObject prefab;
    public float dist1;
    public float dist2 = 5;
    private void Start()
    {
        InvokeRepeating("Spawn", dist1, dist2);
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        dist2 -= 0.005f;
    }
}
