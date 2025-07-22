using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiKetogenezController : MonoBehaviour
{
    public Button b1;
    public Button b2;
    public void Anti1(int price)
    {
        GameManager.isAnti1 = true;
        b1.interactable = false;
        GameManager.Count_of_belok -= price; 
    }

    public void Anti2(int price)
    {
        GameManager.isAnti2 = true;
        b2.interactable = false;
        GameManager.Count_of_belok -= price;
    }
}
