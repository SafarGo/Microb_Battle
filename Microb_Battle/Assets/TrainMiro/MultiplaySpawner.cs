using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiplaySpawner : NetworkBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;
    private void Start()
    {
        spawnPosition = gameObject.transform;
    }
    private void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.E))
            Inst();
    }

    [Command]
    private void Inst()
    {
        Debug.Log("spawning");
        GameObject objectToSpawn = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
        NetworkServer.Spawn(objectToSpawn);
        
    }
}
