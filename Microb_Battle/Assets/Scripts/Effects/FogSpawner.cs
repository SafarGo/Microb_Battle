using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawner : MonoBehaviour
{
    public GameObject segment;
    public int size_X;
    public int size_Z;
    public List<Vector2Int> excludedPositions;

    private void Start()
    {
        Vector3 segSize = segment.GetComponent<Renderer>().bounds.size;
        for (int i = 0; i < size_X; i++)
        {
            for (int j = 0; j < size_Z; j++)
            {
                if (excludedPositions == null || !excludedPositions.Contains(new Vector2Int(i, j)))
                    Instantiate(segment,transform.position + new Vector3(i * segSize.x, 1, j * segSize.z), segment.transform.rotation);
            }
        }
    }
}
