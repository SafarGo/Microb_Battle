using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlukozaDev : MonoBehaviour, IDamageable
{
    public static float speed_of_development;
    public Slider slider;
    public TMP_Text text;
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
    }

    void Update()
    {
        GameManager.Glukoza += speed_of_development * HP;
        slider.value = HP;
        text.text = $"Глюкоза {GameManager.Glukoza}";
        ;
    }
}
