using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStafilococs : NetworkBehaviour
{
    public GameObject prefab;
    public float dist1;
    public float dist2 = 5;
    private void Start()
    {
        if (isServer)
        {
            InvokeRepeating("Spawn", dist1, dist2);
        }
    }

    public void Spawn()
    {
        NetworkSpawnManager.instance.NetworkSpawn(prefab, gameObject.transform);
        dist2 -= 0.005f;
    }
}
