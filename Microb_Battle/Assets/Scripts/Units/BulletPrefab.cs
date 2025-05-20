using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [SerializeField] private float speed;


    private void Update()
    {
        if (PlazmocitController._target.transform != null)
            transform.position = Vector3.MoveTowards(transform.position, PlazmocitController._target.transform.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StafiloccocsController.lives -= 20f;
            Destroy(gameObject);
        }
    }
}
