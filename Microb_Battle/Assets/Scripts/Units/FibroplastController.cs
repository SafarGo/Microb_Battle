using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class FibroplastController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Wall _wall = null;
    public  void SetupTarget(Wall _target)
    {
        _agent.SetDestination(_target.transform.position);
        _wall = _target;
    }

    private void Update()
    {
       if(_agent.remainingDistance <1f)
        {
            _wall.HP += 20f;
            _wall.slider.value += 20f;
            object[] data = new object[] { 2 };
            PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
            Destroy(this.gameObject);
        }
    }


}