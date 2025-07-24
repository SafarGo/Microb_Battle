using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class Saprofit_Controller : MonoBehaviour
{
    public float Speed;
    private NavMeshAgent _agent;
    public float lives;
    private GameObject target;
    public Slider Slider;
    public float price;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
        SetDestination();
        if (GameManager.Count_of_belok >= price)
            GameManager.Count_of_belok -= price;
        else
            Destroy(gameObject);

    }
    private void FixedUpdate()
    {
        Slider.value = lives; 
        if(lives<=0)
        {
            object[] data = new object[] { 1 };
            PhotonNetwork.Instantiate("Belok", transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity, 0, data);
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        CheckState();
    }

    protected void SetDestination()
    {
        //if (!isAtacPlayer) return;
        if (!_agent.hasPath)
        {
            int destination_index = FindNearest();
            if (GameManager.Beloks[destination_index] != null)
            {
                target = GameManager.Beloks[destination_index];
                _agent.SetDestination(target.transform.position);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Belok"))
        {
            int cargo = other.gameObject.GetComponent<Belok_Controller>().count_of_belok;
            GameManager.Count_of_belok += cargo;
            Destroy(other.gameObject);
            Debug.Log($"Захватил {cargo} белка");
        }
        if (other.CompareTag("Ketogenez"))
        {
            lives += Enemy_Upgrade_Units.AttackUnits_HPBonus;
            _agent.speed *= Enemy_Upgrade_Units.AttackUnits_speedBonus;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ketogenez"))
        {
            lives -= Enemy_Upgrade_Units.AttackUnits_HPBonus;
            _agent.speed /= Enemy_Upgrade_Units.AttackUnits_speedBonus;

        }
    }


    private int FindNearest()
    {
        int result = 0;
        float startdist = 10 * 10 ^ 5;
        for (int i = 0; i < GameManager.Beloks.Count; i++)
        {
            if (GameManager.Beloks[i] != null)
            {
                float dist = Vector3.Distance(GameManager.Beloks[i].transform.position, gameObject.transform.position);
                if (dist < startdist)
                {
                    startdist = dist;
                    result = i;
                }
            }
        }
        return result;
    }

    private void CheckState()
    {

        if (!_agent.hasPath || target == null)
        {
            SetDestination();
        }
    }


}
