using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BulletPrefab : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        GameObject target = GetComponentInParent<PlazmocitAttack>()._target;
        if (target != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<StafiloccocsController>().lives -= 20 * GetComponentInParent<PlazmocitAttack>().level;
            Destroy(gameObject);
        }
        if(other.CompareTag("Klost"))
        {
            Destroy(other.gameObject);
            GameManager.Glukoza += 2;
            GameManager.count_of_dead_enemies++;
            Destroy(gameObject);
        }
    }
}