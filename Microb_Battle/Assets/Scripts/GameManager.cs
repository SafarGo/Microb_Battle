using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static float Glukoza = 20;
    public static List<Vector3> points = new List<Vector3>();
    public static int i = 0;
    public static List<GameObject> towers = new List<GameObject>();
    public static int count_of_dead_enemies = 0;
    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> Beloks = new List<GameObject>();
    public GameObject pauseMenu;
    public int count_of_esc = 0;
    public Slider volume;
    public AudioSource heart;
    public static GameManager instance;
    public static bool isGameOver = false;
    public Button button;
    public GameObject CreateTuberStick_button;
    public static bool isKetognez1 = false;
    public static bool isKetognez2 = false;
    public static bool isKetognez3 = false;
    public static bool isKetognez4 = false;
    public static bool isCanSelectTower = true;
    public static bool Storm1;
    public static bool Storm2;
    public static bool Storm3;
    public static float attakUnitsSpeedBonus = 1f;
    public static float attakUnitsHPBonus = 1f;
    public static float streptoFogLifetimeBonus = 1f;
    public static float Count_of_belok;
    public static bool isAttacker;
    public static bool isAnti1;
    public static bool isAnti2;
    public static bool isUpgr1;
    public static bool isUpgr2;
    public static bool isUpgr3;
    public static bool isUpgr4;
    

    private void Start()
    {
        button.onClick.AddListener(MainMenu);
        isAttacker = PhotonNetwork.CurrentRoom.PlayerCount > 1;
    }

    private void Awake()
    {
        isAttacker = PhotonNetwork.CurrentRoom.PlayerCount > 1;
        instance = this;
        Time.timeScale = 1;
        Glukoza = 15;
        Count_of_belok = 15;
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
        if (Input.GetKeyDown(KeyCode.M) && count_of_esc %2 ==0)
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
        if(isUpgr3)
        {
            CreateTuberStick_button.SetActive(true);
        }
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
