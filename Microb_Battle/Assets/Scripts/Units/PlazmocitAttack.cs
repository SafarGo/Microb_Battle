using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlazmocitAttack : PlazmocitController
{
    [SerializeField] private GameObject _bulletPrefab;
    private bool isShooting = false;
    [SerializeField] private float _lives = 100f;
    public Slider slider;


    private void Update()
    {
        StartCoroutine(Attack());
        slider.value = _lives;
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
