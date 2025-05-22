using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStafilococs : MonoBehaviour
{
    public GameObject prefab;
    public int dist;
    private void Start()
    {
        InvokeRepeating("Spawn", dist, dist);
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
       // FindObjectOfType<NavMeshUpdater>().UpdateNavMesh();
    }
}
