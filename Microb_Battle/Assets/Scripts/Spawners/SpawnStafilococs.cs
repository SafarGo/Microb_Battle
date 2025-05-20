using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStafilococs : MonoBehaviour
{
    public GameObject prefab;
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    public void Spawn()
    {
        Instantiate(prefab);
    }
}
