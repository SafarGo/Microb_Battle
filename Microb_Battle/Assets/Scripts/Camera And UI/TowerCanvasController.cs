using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _player_cam;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = MainTowerController.HP;
        gameObject.transform.LookAt(_player_cam.transform);
    }
}
