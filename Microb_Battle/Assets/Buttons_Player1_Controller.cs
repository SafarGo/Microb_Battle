using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttons_Player1_Controller : MonoBehaviour
{
    public Button Create_Sin_Stick;
    public Button Create_Fibroplast;
    public Button Create_Sen_Stick;
    public int count_of_Gl_Sin;
    public int count_of_Gl_Fibr;
    public int count_of_Gl_Sen;

    private void Start()
    {
        Create_Fibroplast.interactable = false;
        Create_Sen_Stick.interactable = false;
        Create_Sen_Stick.interactable = false;
    }

    private void FixedUpdate()
    {
        if(GameManager.Glukoza> count_of_Gl_Sin)
        {
            Create_Sin_Stick.interactable = true;
        }
        else
        {
            Create_Sin_Stick.interactable= false;
        }
        if (GameManager.Glukoza > count_of_Gl_Fibr)
        {
            Create_Fibroplast.interactable = true;
        }
        else
        {
            Create_Fibroplast.interactable = false;
        }
        if (GameManager.Glukoza > count_of_Gl_Sen)
        {
            Create_Sen_Stick.interactable = true;
        }
        else
        {
            Create_Sen_Stick.interactable = false;
        }
    }
}
