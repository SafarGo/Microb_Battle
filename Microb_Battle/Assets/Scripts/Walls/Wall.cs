using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour, IDamageable
{
    public Transform nodeA, nodeB;
    public Slider slider;

    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
            GameObject.Find("WallsBuilder").GetComponent<BuildWalls>().walls.Remove(this);
            Destroy(gameObject);
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
        float length = direction.magnitude;
        transform.localScale = new Vector3(
            1,
            5,
            length
        );
    }

    void Update()
    {
        slider.value = HP;  
    }
}