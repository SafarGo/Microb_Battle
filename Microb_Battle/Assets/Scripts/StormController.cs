using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StormController : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public List<GameObject> buttons = new List<GameObject>();
    public GameObject buttonUlt;

    private void FixedUpdate()
    {
        Check_Button(0, 30, GameManager.Storm1);
        Check_Button(1, 45, GameManager.Storm2);
        Check_Button(2, 60, GameManager.Storm3);
    }

        public void Storm1(int price)
    {
        GameManager.Storm1 = true;
        ParticleSystem.CollisionModule collisionModule = ParticleSystem.collision;
        LayerMask desiredLayers = LayerMask.GetMask( "Units");
        collisionModule.collidesWith = desiredLayers;
        GameManager.Glukoza -= price;
    }

    public void Storm2(int price)
    {
        GameManager.Storm2 = true;
        ParticleSystem.CollisionModule collisionModule = ParticleSystem.collision;
        LayerMask desiredLayers = LayerMask.GetMask("DefendUnits", "Units", "Clickable");
        collisionModule.collidesWith = desiredLayers;
        GameManager.Glukoza -= price;
        ParticleSystem.gravityModifier -= 1;
    }

    public void Storm3(int price)
    {
        GameManager.Storm3 = true;
        ParticleSystem.CollisionModule collisionModule = ParticleSystem.collision;
        LayerMask desiredLayers = LayerMask.GetMask("DefendUnits", "Units", "Clickable", "Nodes");
        collisionModule.collidesWith = desiredLayers;
        GameManager.Glukoza -= price;
        ParticleSystem.gravityModifier = 1;
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

    private void Update()
    {
        if(GameManager.Storm1)
        {
            buttonUlt.SetActive(true);
        }
        else
        {
            buttonUlt.SetActive(false);
        }
        if(GameManager.Glukoza >= 25)
        {
           buttonUlt.GetComponent<Button>().interactable = true;
        }
        else
        {
            buttonUlt.GetComponent<Button>().interactable = false;
        }
    }

    public void Ult()
    {
        if (GameManager.Glukoza >= 25)
        {
            ParticleSystem.Play();
            GameManager.Glukoza -= 25;
        }
    }
}
