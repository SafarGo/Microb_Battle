using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button b1;
    public Button b2;

    private void Start()
    {
        b1.onClick.AddListener(EnterGame);
        b2.onClick.AddListener(Exit);
    }


    void Exit()
    {
        Application.Quit();
    }

    void EnterGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

}