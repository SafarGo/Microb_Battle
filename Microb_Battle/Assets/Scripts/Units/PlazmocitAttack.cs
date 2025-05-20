using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazmocitAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private bool isShooting = false; 


    private void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (PlazmocitController._target != null && !isShooting)
        {
            isShooting=true;
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(PlazmocitController._attack_time);
            isShooting=!isShooting;
        }
    }
}
