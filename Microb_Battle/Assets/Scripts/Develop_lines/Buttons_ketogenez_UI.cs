using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_ketogenez_UI : MonoBehaviour
{
    GameObject zone;
    public List<GameObject> buttons = new List<GameObject>();

    private void FixedUpdate()
    {
        Check_Button(0, 30, GameManager.isKetognez1);
        Check_Button(1,45, GameManager.isKetognez2);
        Check_Button(2, 60, GameManager.isKetognez3);
        Check_Button(3, 75, GameManager.isKetognez4);

    }
    public void Ket1(int price)
    {
        GameManager.isKetognez1 = true;
        zone = PhotonNetwork.Instantiate("Zone", new Vector3(0,0,0), Quaternion.identity, 0);
        buttons[0].GetComponent<Button>().interactable = false;
        GameManager.Glukoza -= price;
    }
    public void Ket2(int price)
    {
        GameManager.isKetognez2 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[1].GetComponent<Button>().interactable = false;
        GameManager.Glukoza -= price;
    }
    public void Ket3(int price)
    {
        GameManager.isKetognez3 = true;
        zone.transform.localScale = new Vector3(zone.transform.localScale.x * 1.2f, 1, zone.transform.localScale.z * 1.2f);
        buttons[2].GetComponent<Button>().interactable = false;
        GameManager.Glukoza -= price;
    }
    public void Ket4(int price)
    {
        GameManager.isKetognez4 = true;
        buttons[3].GetComponent<Button>().interactable = false;
        GameManager.Glukoza -= price;
    }

    public void Check_Button(int index, int price, bool ket)
    {
        if (GameManager.Glukoza >= price && !ket)
        {
            buttons[index].GetComponent<Button>().interactable = true;
        }
        else
        {
            buttons[index].GetComponent<Button>().interactable = false;
        }
    }
}
