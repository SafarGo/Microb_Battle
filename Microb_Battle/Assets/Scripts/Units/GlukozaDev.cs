using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlukozaDev : MonoBehaviour
{
    public static float speed_of_development;
    public static float lives = 100f;
    public Slider slider;

    void Update()
    {
        GameManager.Glukoza += speed_of_development * lives;
        slider.value = lives;
    }
}
