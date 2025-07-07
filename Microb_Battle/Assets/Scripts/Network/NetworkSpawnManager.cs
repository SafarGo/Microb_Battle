using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSpawnManager : NetworkBehaviour
{
    public static NetworkSpawnManager instance;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void NetworkSpawn(GameObject pref, Transform trans)
    {
        if (isServer)
        {
            GameObject prefab = Instantiate(pref, trans.position, Quaternion.identity);
            NetworkServer.Spawn(prefab);
        }
    }
}
