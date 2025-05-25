using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlukozaDev : MonoBehaviour, IDamageable
{
    public static float speed_of_development;
    public Slider slider;
    public TMP_Text level_text;
    public int level = 1;
    public TMP_Text text;
    public Button upgrade_button;
    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");
        if (HP <= 0)
        {
            Destroy(this.gameObject);
            GameManager.towers.Remove(this.gameObject);
        }
    }

    private void Awake()
    {
        GameManager.towers.Add(this.gameObject);
        upgrade_button.onClick.AddListener(UpgradeeButton);
        
    }

    private void Start()
    {
        InvokeRepeating("Develop", 0,1);
    }

    void Update()
    {
        slider.value = HP;
        text.text = $"Глюкоза {GameManager.Glukoza}";
        level_text.text = $"Ур. {level}";
        Upgrade();
    }

    void Upgrade()
    {
        if (GameManager.count_of_dead_enemies > level * 10)
        {
            upgrade_button.gameObject.SetActive(true);
        }
        else
        {
            upgrade_button.gameObject.SetActive(false);
        }
    }

    public void UpgradeeButton()
    {
        level++;
        GameManager.count_of_dead_enemies = 0;
    }

    void Develop()
    {
        GameManager.Glukoza += Mathf.Floor(HP/100 * level);
    }
}
