using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections;

public class SennayaPalochka_controller : MonoBehaviourPun, IDamageable
{
   
    public Slider Slider_hp;
    public int count_of_spawn_belok;


    public float HP { get; set; } = 60f;

    void Awake()
    {
        GameManager.towers.Add(this.gameObject);
    }

    private void FixedUpdate()
    {
        Slider_hp.value = HP;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Slider_hp.value = HP;
        if(HP<=0)
        {
            GameManager.towers.Remove(this.gameObject);
            object[] data = new object[] { count_of_spawn_belok };
            PhotonNetwork.Instantiate("Belok", transform.position, Quaternion.identity, 0, data);
            Destroy(gameObject);
        }
    }


    
}