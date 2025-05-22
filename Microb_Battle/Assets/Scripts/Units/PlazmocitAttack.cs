using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazmocitAttack : PlazmocitController
{
    [SerializeField] private GameObject _bulletPrefab;
    private bool isShooting = false;


    private void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (_target != null && !isShooting)
        {
            isShooting=true;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.transform.SetParent(transform);
            yield return new WaitForSeconds(_attack_time);
            isShooting=!isShooting;
        }
    }
}
