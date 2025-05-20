using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP_Canvas_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _player_cam;

    private void Update()
    {
        gameObject.transform.LookAt(_player_cam.transform);
    }
}
