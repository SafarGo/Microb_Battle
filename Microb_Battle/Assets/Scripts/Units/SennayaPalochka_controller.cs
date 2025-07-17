using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections;

public class SennayaPalochka_controller : MonoBehaviourPun, IDamageable
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float launchForce = 15f;
    public float launchAngle = 45f;
    [SerializeField] Transform enemy_position;
    public Slider Slider_hp;
    bool _isCanShoot = true;


    public float HP { get; set; } = 60f;

    void Awake()
    {
        GameManager.towers.Add(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Slider_hp.value = HP;
        if(HP<=0)
        {
            GameManager.towers.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (!photonView.IsMine) return; // Только владелец управляет стрельбой и поворотом

        if (_isCanShoot && enemy_position != null)
        {
            Shoot(enemy_position);
            _isCanShoot=false;
            StartCoroutine(Perezariadka());
        }
        if (enemy_position != null)
        {
            transform.LookAt(enemy_position);
        }
        //else
        //{
        //    transform.LookAt(transform.position);
        //}
        Slider_hp.value = HP;
    }

    public void Shoot(Transform target)
    {
        if (target == null) return;

        // Создаём снаряд через PhotonNetwork.Instantiate
        GameObject projectile = PhotonNetwork.Instantiate(projectilePrefab.name, firePoint.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 targetPos = target.position;
            Vector3 startPos = firePoint.position;

            // Вектор до цели по XZ (горизонтальная плоскость)
            Vector3 toTarget = targetPos - startPos;
            float yOffset = toTarget.y; // разница по высоте
            toTarget.y = 0; // только горизонтальное расстояние
            float distance = toTarget.magnitude;

            float angle = launchAngle * Mathf.Deg2Rad;

            // Формула для расчёта начальной скорости (без сопротивления воздуха)
            float gravity = Physics.gravity.magnitude;
            float height = yOffset;
            float tanAngle = Mathf.Tan(angle);

            float denominator = 2 * (distance * tanAngle - height);
            if (denominator <= 0.01f)
            {
                Debug.LogWarning("Цель слишком близко или слишком высоко для заданного угла!");
                return;
            }

            float velocity = Mathf.Sqrt(gravity * distance * distance / denominator);

            // Направление выстрела (горизонтальное)
            Vector3 dir = toTarget.normalized;

            // Вектор скорости с учётом угла
            Vector3 velocityVector = dir * velocity * Mathf.Cos(angle) + Vector3.up * velocity * Mathf.Sin(angle);

            rb.AddForce(velocityVector, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy_position = other.gameObject.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!photonView.IsMine) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy_position = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!photonView.IsMine) return;
        if (other.gameObject.CompareTag("Enemy"))
            enemy_position = null;
    }

    IEnumerator Perezariadka()
    {
        yield return new WaitForSeconds(4);
        _isCanShoot = true;
    }
}