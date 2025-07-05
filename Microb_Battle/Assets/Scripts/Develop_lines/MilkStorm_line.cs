using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkStorm_line : MonoBehaviour
{
    public GameObject storm;
    private ParticleSystem sys;
    public static MilkStorm_line instance;
    public List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        sys = storm.GetComponent<ParticleSystem>();
        instance = this;
    }
    public void Storm1()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units"));
        GameManager.isMilkStorm2 = true;
        GameManager.isMilkStorm1 = false;
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = true;
        buttons[2].GetComponent<Button>().interactable = false;
    }

    public void Storm2()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units")) | (1 << LayerMask.NameToLayer("Attack"));
        var _speed = sys.main.startSpeed;
        var emission = sys.emission;
        emission.rateOverTime = 100;
        _speed = 20f;
        GameManager.isMilkStorm3 = true;
        GameManager.isMilkStorm2 = false;
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        buttons[2].GetComponent<Button>().interactable = true;
    }

    public void Storm3()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units")) | (1 << LayerMask.NameToLayer("Attack")) | (1 << LayerMask.NameToLayer("Nodes"));
        var _speed = sys.main.startSpeed;
        _speed = 30f ;
        var emission = sys.emission;
        emission.rateOverTime = 200;
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        buttons[2].GetComponent<Button>().interactable = false;
    }

}
