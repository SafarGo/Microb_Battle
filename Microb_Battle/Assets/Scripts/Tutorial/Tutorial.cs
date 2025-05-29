using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public List<string> frazes = new List<string>();
    public Button button;
    public Button button1;
    int i = 0;
    public TMP_Text text;
    private void Start()
    {
        button.onClick.AddListener(ShowText);
        button1.onClick.AddListener(Skip);
    }

    void ShowText()
    {
        i++;
        if (i <= frazes.Count)
        {
            text.text = frazes[i];
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Skip()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
