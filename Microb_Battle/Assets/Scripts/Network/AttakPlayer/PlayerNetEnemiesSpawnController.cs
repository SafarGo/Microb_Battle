using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetEnemiesSpawnController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private List<GameObject> enemies; 
    void Start()
    {
        if (gameObject.tag != "NatPlayer_2") Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
            {
                    Vector3 spawnPos = hit.point;
                float distance = Vector3.Distance(new Vector3(0,0,0), spawnPos);
                if (distance > 13)
                {
                    PhotonNetwork.Instantiate(enemies[0].name, spawnPos, Quaternion.identity);
                    Debug.Log(hit.collider.gameObject.layer);
                }
            }
        }
    }
}
