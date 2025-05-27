using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStafilococs : MonoBehaviour
{
    public GameObject prefab;
    public int dist1, dist2;
    private void Start()
    {
        InvokeRepeating("Spawn", dist1, dist2);
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
