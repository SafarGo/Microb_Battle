using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlazmocitAttack : PlazmocitController
{
    [SerializeField] protected GameObject _bulletPrefab;
    private bool isShooting = false;

    void Start()
    {
        if (!gameObject.transform.parent.GetComponent<PhotonView>().IsMine)
        {
            gameObject.transform.parent.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }


    private void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (_target != null && !isShooting)
        {
            isShooting=true;
            float time = _attack_time;
            GameObject bullet = PhotonNetwork.Instantiate(_bulletPrefab.name, transform.position, transform.rotation);
            bullet.GetComponent<BulletPrefab>().target = _target;
            bullet.GetComponent<BulletPrefab>().attack = this;
            //bullet.transform.SetParent(transform);
            yield return new WaitForSeconds(time);
            isShooting=!isShooting;
        }
    }
}
