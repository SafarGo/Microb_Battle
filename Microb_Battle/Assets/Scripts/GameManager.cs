using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float Glukoza = 100;
    public static List<Vector3> points = new List<Vector3>();
    public static int i = 0;
    public static List<GameObject> towers = new List<GameObject>();
    public static int count_of_dead_enemies = 0;
}
