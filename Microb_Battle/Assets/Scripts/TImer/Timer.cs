using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time = 300f;
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        time -= Time.deltaTime;
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        text.text = $"{minutes:00}:{seconds:00}";
    }
}
