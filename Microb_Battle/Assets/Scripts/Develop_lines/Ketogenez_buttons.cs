using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class  Ketogenez_buttons: MonoBehaviour 
{
    public void Ketogenez1(NavMeshAgent _agent)
    {
        if(Enemy_Upgrade_Units.AttackUnits_speedBonus == 1)
        _agent.speed = _agent.speed*0.5f;
        else
            _agent.speed = _agent.speed*0.6f;
    }
    public void Ketogenez2(NavMeshAgent _agent)
    {
        if (Enemy_Upgrade_Units.AttackUnits_HPBonus == 0)
            _agent.speed = _agent.speed * 0.65f;
        else
            _agent.speed = _agent.speed * 0.75f;
    }
    public void Ketogenez3(GameObject obj)
    {
        obj.GetComponent<IDamageable>().HP *= 1.3f;
        Debug.Log(obj.GetComponent<IDamageable>().HP);
    }
    public void Super_Ketogenez(NavMeshAgent _agent)
    {
        _agent.speed = _agent.speed * 0.5f;
        
    }
    public void Super_Ketogenez(GameObject obj)
    {
        obj.GetComponent<IDamageable>().HP *= 1.3f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            NavMeshAgent _other_agent = other.gameObject.GetComponent<NavMeshAgent>();
            if (GameManager.isKetognez1)
            {
                Ketogenez1(_other_agent);
            }
            if(GameManager.isKetognez2)
            {
                Ketogenez2(_other_agent);
            }
            if(GameManager.isKetognez4)
            {
                Super_Ketogenez(_other_agent);
            }
            
        }
        if(other.gameObject.CompareTag("Unit"))
        {
            Debug.Log("!");
            if (GameManager.isKetognez3)
            {
                Ketogenez3(other.gameObject);
            }
            if(GameManager.isKetognez4)
            {
                Super_Ketogenez(other.gameObject);
            }
        }
    }
}
