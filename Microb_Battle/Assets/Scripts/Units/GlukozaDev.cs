using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlukozaDev : MonoBehaviour, IDamageable
{
    public static float speed_of_development;
    public Slider slider;
    public TMP_Text level_text;
    public int level = 1;
    public TMP_Text text;
    public Button upgrade_button;
    public float HP { get; set; } = 100f;
    private PhotonView photonView;
    public int Efficiency = 3;
    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        Debug.Log($"Башня получила {damage} урона! Осталось HP: {HP}");

        photonView.RPC("SyncGlucosDevHP", RpcTarget.Others, HP);
        if (HP <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
            GameManager.towers.Remove(this.gameObject);
        }
    }

    [PunRPC]
    private void SyncGlucosDevHP(float lives)
    {
        HP = lives;
        slider.value = HP;
        if (HP <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
            GameManager.towers.Remove(this.gameObject);
        }
    }

    private void Awake()
    {
         //if (GameManager.isAttacker) return;

        GameManager.towers.Add(this.gameObject);
        upgrade_button.onClick.AddListener(UpgradeeButton);
        
    }

    private void OnMouseEnter()
    {
        if (GameManager.isAttacker) return;
        ShowInfo();
    }

    private void OnMouseExit()
    {
        if (GameManager.isAttacker) return;
        ClearInfo();
    }

    private void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

        InvokeRepeating("Develop", 0,1);
    }

    void Update()
    {
        if (GameManager.isAttacker) return;
        slider.value = HP;
        text.text = $"Глюкоза {GameManager.Glukoza}";
        level_text.text = $"Ур. {level}";
        Upgrade();
    }

    void Upgrade()
    {
        if (GameManager.isAttacker) return;
        if (GameManager.count_of_dead_enemies > level * 10 && level<3)
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
        if (GameManager.isAttacker) return;
        level++;
        GameManager.count_of_dead_enemies -= level * 10;
    }

    void Develop()
    {
        if (GameManager.isAttacker) return;
        if (GameManager.isAttacker) return;
        GameManager.Glukoza += Mathf.Floor(1/level);
    }

    void ShowInfo()
    {
        if (GameManager.isAttacker) return;
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = $"Выроботка глюкозы\n" +
            $"Уровень {level}\n"+
            $"Производительность: {Mathf.Floor(HP / 100 * level)} сек";
    }

    void ClearInfo()
    {
        if (GameManager.isAttacker) return;
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = "";
    }
}
