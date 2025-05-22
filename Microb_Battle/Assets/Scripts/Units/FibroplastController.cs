using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FibroplastController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject wallSegmentPrefab;
    private int myPointIndex;
    public float HP = 100f;

    private void Start()
    {
        if (GameManager.points.Count == 0) return;

        if (GameManager.i < GameManager.points.Count)
        {
            myPointIndex = GameManager.i;
            agent.SetDestination(GameManager.points[myPointIndex]);
            GameManager.i++;
        }
        else
        {
            GameManager.i = 0;
            myPointIndex = GameManager.i;
            agent.SetDestination(GameManager.points[myPointIndex]);
        }
    }

    public void BuildWallSegment(int pointIndex)
    {
        if (GameManager.points.Count == 0) return;

        Vector3 currentPoint = GameManager.points[pointIndex];
        Vector3 nextPoint = GameManager.points[(pointIndex + 1) % GameManager.points.Count];

        Vector3 direction = (nextPoint - currentPoint).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        GameObject wall = Instantiate(wallSegmentPrefab, currentPoint, rotation);
        wall.GetComponent<Wall>().HP += 20;
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            BuildWallSegment(myPointIndex);
        }
    }
}