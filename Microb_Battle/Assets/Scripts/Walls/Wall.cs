using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
    public Transform nodeA, nodeB;

    public float HP { get; set; } = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
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

    
}