using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections.Generic;
using Unity.AI.Navigation;

public class BuildWalls : MonoBehaviour
{
    public GameObject wallPrefab;
    public LayerMask nodeLayer;  
    public float maxWallLength = 2f;
    public Button buildButton; 
    public NavMeshSurface surface;
    private List<Wall> walls = new List<Wall>();
    private Transform selectedNodeA, selectedNodeB;

    void Start()
    {
        buildButton.gameObject.SetActive(false);
        buildButton.onClick.AddListener(BuildWall);
    }

    void Update()
    {
        // Выбор узлов
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, nodeLayer))
            {
                if (selectedNodeA == null)
                {
                    selectedNodeA = hit.transform;
                    HighlightNode(selectedNodeA, true);
                }
                else if (selectedNodeB == null && hit.transform != selectedNodeA)
                {
                    selectedNodeB = hit.transform;
                    HighlightNode(selectedNodeB, true);
                    buildButton.gameObject.SetActive(true);
                }
            }
        }

        // Отмена по ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearSelection();
        }
    }

    void BuildWall()
    {
        if (selectedNodeA == null || selectedNodeB == null) return;

        // Проверяем расстояние
        float distance = Vector3.Distance(selectedNodeA.position, selectedNodeB.position);
        if (distance > maxWallLength)
        {
            Debug.Log("Слишком длинная стена!");
            ClearSelection();
            return;
        }

        // Проверяем, нет ли уже стены
        if (WallExists(selectedNodeA, selectedNodeB))
        {
            Debug.Log("Здесь уже есть стена!");
            ClearSelection();
            return;
        }


        // Создаём стену
        GameObject newWall = Instantiate(wallPrefab);
        Wall wall = newWall.GetComponent<Wall>();
        wall.Setup(selectedNodeA, selectedNodeB);
        walls.Add(wall);
        surface.BuildNavMesh();
        ClearSelection();
    }

    void ClearSelection()
    {
        if (selectedNodeA != null) HighlightNode(selectedNodeA, false);
        if (selectedNodeB != null) HighlightNode(selectedNodeB, false);
        selectedNodeA = null;
        selectedNodeB = null;
        buildButton.gameObject.SetActive(false);
    }

    bool WallExists(Transform nodeA, Transform nodeB)
    {
        foreach (Wall wall in walls)
        {
            if ((wall.nodeA == nodeA && wall.nodeB == nodeB) ||
                (wall.nodeA == nodeB && wall.nodeB == nodeA))
                return true;
        }
        return false;
    }

    void HighlightNode(Transform node, bool highlight)
    {
        node.GetComponent<Renderer>().material.color =
            highlight ? Color.yellow : Color.white;
    }
}