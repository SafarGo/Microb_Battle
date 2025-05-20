using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazmocitController : MonoBehaviour
{
    public static float _attack_time = 1f;
    public static GameObject _target;

    private void OnTriggerEnter(Collider other)
    {
        if(_target == null)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_target == null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
        }
    }
}
