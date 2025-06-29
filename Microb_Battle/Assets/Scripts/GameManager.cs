using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float Glukoza = 20;
    public static List<Vector3> points = new List<Vector3>();
    public static int i = 0;
    public static List<GameObject> towers = new List<GameObject>();
    public static int count_of_dead_enemies = 0;
    public static List<GameObject> enemies = new List<GameObject>();
    public GameObject pauseMenu;
    public int count_of_esc = 0;
    public Slider volume;
    public AudioSource heart;
    public static GameManager instance;
    public static bool isGameOver = false;
    public Button button;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        Glukoza = 15;
    }
    private void Start()
    {
        button.onClick.AddListener(MainMenu);
    }

    public static void AttackAllStaf()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && count_of_esc %2 ==0)
        {
            pauseMenu.SetActive(true);
            count_of_esc++;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.M) && count_of_esc % 2 != 0)
        {
            pauseMenu.SetActive(false);
            count_of_esc++;
            Time.timeScale = 1;
        }
        heart.volume = volume.value;
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
