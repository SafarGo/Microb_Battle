using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour, IDamageable
{
    public Transform nodeA, nodeB;

    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            GameObject.Find("WallsBuilder").GetComponent<BuildWalls>().walls.Remove(this);
            Die();
        }
    }
    public void Setup(Transform a, Transform b)
    {
        nodeA = a;
        nodeB = b;
        UpdateWallPosition();
    }

    void UpdateWallPosition()
    {
        transform.position = (nodeA.position + nodeB.position) / 2f;

        Vector3 direction = nodeB.position - nodeA.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Rotate(0, 180, 0);
        float length = direction.magnitude;
        transform.localScale = new Vector3(
            0.5f,
            3f,
            length+1.5f
        );
    }

    void Die()
    {
            GameObject.Find("WallsBuilder").GetComponent<BuildWalls>().walls.Remove(this);
            Destroy(gameObject);
    }


    private void OnMouseExit()
    {
        ClearInfo();
    }

    private void OnMouseEnter()
    {
        ShowInfo();
    }
    void ShowInfo()
    {
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = $"Коллагеновая стенка\n" +
            $"Преграждает стафилоккокам путь\n" +
            $"Уязвима для клостридий";
    }
    

    void ClearInfo()
    {
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = "";
    }
}