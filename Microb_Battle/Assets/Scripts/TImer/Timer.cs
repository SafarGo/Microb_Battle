using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time = 300f;
    [SerializeField] private TMP_Text text;
    public GameObject Player_1_Win;

    private void Start()
    {
        time = 300f;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        text.text = $"{minutes:00}:{seconds:00}";
        if(time<=0 && !GameManager.isGameOver)
        {
           Player_1_Win.SetActive(true);
        }
    }
}
