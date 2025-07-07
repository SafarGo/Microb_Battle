using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartSpawnCubeExample : NetworkBehaviour
{
    public GameObject instPrefab;
    void Start()
    {
        if (isServer)
        {
            GameObject prefab = Instantiate(instPrefab, gameObject.transform.position, Quaternion.identity);
            NetworkServer.Spawn(prefab);
        }
    }

}
