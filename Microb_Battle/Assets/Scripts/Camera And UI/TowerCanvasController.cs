using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _player_cam;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject tower;

    private void Update()
    {
        slider.value = tower.GetComponent<IDamageable>().HP;
        gameObject.transform.LookAt(_player_cam.transform);
    }
}
