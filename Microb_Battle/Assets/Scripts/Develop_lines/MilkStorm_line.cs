using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkStorm_line : MonoBehaviour
{
    public GameObject storm;
    private ParticleSystem sys;
    public static MilkStorm_line instance;

    private void Start()
    {
        sys = storm.GetComponent<ParticleSystem>();
        instance = this;

    }
    public void Storm1()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units"));
        GameManager.isMilkStorm1 = true;
    }

    public void Storm2()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units")) | (1 << LayerMask.NameToLayer("Attack"));
        var _speed = sys.main.startSpeed;
        _speed = 20f;
        GameManager.isMilkStorm2 = true;
        GameManager.isMilkStorm1 = false;
    }

    public void Storm3()
    {
        var collision = sys.collision;
        collision.collidesWith = (1 << LayerMask.NameToLayer("Units")) | (1 << LayerMask.NameToLayer("Attack")) | (1 << LayerMask.NameToLayer("Nodes"));
        var _speed = sys.main.startSpeed;
        _speed = 30f ;
        GameManager.isMilkStorm3 = true;
        GameManager.isMilkStorm2 = false;
    }

}
