using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class Saprofit_Controller : MonoBehaviourPun
{
    public float Speed;
    private NavMeshAgent _agent;
    public int HP;
    private GameObject target;
    bool isSelected = false;
    public LayerMask layer;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
        GameManager.Glukoza -= 2;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        if (isSelected && Input.GetMouseButtonDown(0))
        {
            Debug.Log($"{isSelected}");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);
                if (hit.transform != transform && isSelected)
                {
                    _agent.SetDestination(hit.point);
                    Debug.Log("Set destination: " + hit.point);
                    isSelected = false;
                }
            }
            else
            {
                Debug.Log("Raycast missed");
            }
        }
    }

    private void OnMouseDown()
    {
        if (photonView.IsMine)
        {
            isSelected = true;
            Debug.Log("Object selected");
        }
    }


}
