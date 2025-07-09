using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlazmocitController : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _attack_time = 3f;
    public GameObject _target;
    public Slider slider;
    public GameObject parent;
    public int level = 1;
    [SerializeField] private Button button;
    private TMP_Text text;
    bool isUpgraded = false;

    void Awake()
    {

        text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        GameManager.towers.Add(this.gameObject);
        slider.value = HP;
        button.onClick.AddListener(Upgrade);
        button.gameObject.SetActive(false);
    }
    public float HP { get; set; } = 100f;

    //void Start()
    //{
    //    if (parent.GetComponent<PhotonView>().Owner == PhotonNetwork.MasterClient)
    //        if (parent.GetComponent<PhotonView>().IsMine)
    //            Destroy(this);
    //}

    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
        if (HP <= 0)
        {
            //if (parent.GetComponent<PhotonView>().Owner == PhotonNetwork.MasterClient)
            //{
            //   PhotonNetwork.Destroy(parent);
            //}
            Destroy(parent);
            GameManager.towers.Remove(this.gameObject);
        }
    }

    private void Update()
    {
        if(GameManager.Glukoza>=10 && level<5)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
        if(isUpgraded)
        {
            ShowInformation();
            isUpgraded = false;
        }
    }

    private void OnMouseEnter()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Clickable"))
        ShowInformation();
    }
    private void OnMouseExit()
    {
        text.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_target == null)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
            if (other.gameObject.CompareTag("Klost"))
            {
                _target = other.gameObject;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_target == null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _target = other.gameObject;
            }
        }
    }

    public void Upgrade()
    {
        if (level < 5)
        {
            _attack_time  -= 0.3f;
            GameManager.Glukoza -= 10;
            button.gameObject.SetActive(false);
            level++;
            isUpgraded = true;
        }
    }

    private void ShowInformation()
    {
        
        text.text = "Плазмоцит.\n" +
            $"Уровень {level}\n" +
            $"Урон {level * 10}\n" +
            $"Скорость атаки {_attack_time} сек\n" +
            $"Наносит урон Стафилококкам и клостридиям";
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsReading)
    //    {
    //        stream.SendNext(HP);
    //    }
    //    else
    //    {
    //        HP = (float)(stream.ReceiveNext());
    //    }
    //}
}
