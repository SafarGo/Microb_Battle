using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class FibroplastController : MonoBehaviourPun
{
    [SerializeField] private NavMeshAgent _agent;
    public int price;
    private Wall _wall = null;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
        GameManager.towers.Add(gameObject);

    }

    public  void SetupTarget(Wall _target)
    {
        _agent.SetDestination(_target.transform.position);
        _wall = _target;
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _wall.gameObject.transform.position);
       if(distance < 2f)
        {
            _wall.HP += 20f;
            _wall.slider.value += 20f;
            //PhotonNetwork.Destroy(transform.parent.gameObject);
            PhotonNetwork.Destroy(gameObject);
        }
    }


}