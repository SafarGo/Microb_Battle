using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetEnemiesSpawnController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] int selektedIndex;
    public static PlayerNetEnemiesSpawnController instance { get; private set; }
    void Start()
    {
        if (gameObject.tag != "NatPlayer_2") Destroy(this);
        instance = this;
    }

    void Update()
    {
            if (Input.mousePosition.x >= Screen.width - Screen.width / 5.5f
                || Input.mousePosition.x <= Screen.width / 5.5f)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
                    {
                        Vector3 spawnPos = hit.point;
                        float distance = Vector3.Distance(new Vector3(0, 0, 0), spawnPos);
                        if (distance > 13)//���������� 1
                        {
                            PhotonNetwork.Instantiate(enemies[selektedIndex].name, spawnPos, Quaternion.identity);
                            Debug.Log(hit.collider.gameObject.layer);
                        }
                    }
                }
            }
    }

    public void SelectAtackUnit(int index)
    {
        selektedIndex = index;
    }
}
