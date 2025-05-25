using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlazmocitController : MonoBehaviour, IDamageable
{
    public float _attack_time = 1f;
    public GameObject _target;
    public Slider slider;
    public GameObject parent;
    public int level = 1;
    [SerializeField] private Button button;
    void Awake()
    {
        GameManager.towers.Add(this.gameObject);
        slider.value = HP;
        button.onClick.AddListener(Upgrade);
        button.gameObject.SetActive(false);
    }
    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
        if (HP <= 0)
        {
            Destroy(parent);
            GameManager.towers.Remove(this.gameObject);
        }
    }

    private void Update()
    {
        if(GameManager.Glukoza>=10)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Clickable"))
        ShowInformation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_target == null)
        {
            if(other.gameObject.CompareTag("Enemy"))
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
            level++;
            _attack_time -= 0.3f;
            GameManager.Glukoza -= 10;
        button.gameObject.SetActive(false);
    }

    private void ShowInformation()
    {
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = "Плазмоцит.\n" +
            $"Уровень {level}\n" +
            $"Урон {level * 20}\n" +
            $"Скорость аттаки {_attack_time} сек\n" +
            $"Наносит урон Стафилококкам и клостридиям";
    }
}
