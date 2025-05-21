using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Glukoza = 10;
    public static List<Vector3> points = new List<Vector3>();
    public static int i = 0;
    public static int count_of_ready_walls = 0;

    private void Start()
    {
        GetCirclePoints(new Vector3(0, 0, 0), 3f, 6);
    }

    public List<Vector3> GetCirclePoints(Vector3 center, float radius, int segments)
    {
        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2f / segments;
            float x = center.x + Mathf.Cos(angle) * radius;
            float z = center.z + Mathf.Sin(angle) * radius;
            points.Add(new Vector3(x, center.y, z));
        }
        return points;
        
    }
}
