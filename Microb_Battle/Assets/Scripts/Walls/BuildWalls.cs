using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections.Generic;
using Unity.AI.Navigation;
using TMPro;

public class BuildWalls : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject towerPrefab;
    public LayerMask nodeLayer;  
    public float maxWallLength = 2f;
    public Button buildButton;
    public Button buildTurelbutton;
    public NavMeshSurface surface;
    public List<Wall> walls = new List<Wall>();
    public List<GameObject> towers = new List<GameObject>();
    private Transform selectedNodeA, selectedNodeB;
    public TMP_Text text;

    void Start()
    {
        buildButton.gameObject.SetActive(false);
        buildTurelbutton.gameObject.SetActive(false);
        buildButton.onClick.AddListener(BuildWall);
        buildTurelbutton.onClick.AddListener(BuildTower);
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
                    buildTurelbutton.gameObject.SetActive(true);
                }
                else if (selectedNodeB == null && hit.transform != selectedNodeA)
                {
                    selectedNodeB = hit.transform;
                    HighlightNode(selectedNodeB, true);
                    buildButton.gameObject.SetActive(true);
                    buildTurelbutton.gameObject.SetActive(false);
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
        if (GameManager.Glukoza >= 5)
        {
            if (selectedNodeA == null || selectedNodeB == null) return;

            float distance = Vector3.Distance(selectedNodeA.position, selectedNodeB.position);
            if (distance > maxWallLength)
            {
                Debug.Log("Слишком длинная стена!");
                ClearSelection();
                return;
            }

            if (WallExists(selectedNodeA, selectedNodeB))
            {
                Debug.Log("Здесь уже есть стена!");
                ClearSelection();
                return;
            }

            GameObject newWall = Instantiate(wallPrefab);
            Wall wall = newWall.GetComponent<Wall>();
            wall.Setup(selectedNodeA, selectedNodeB);
            walls.Add(wall);
            surface.BuildNavMesh();
            GameManager.Glukoza -= 5;
            ClearSelection();
        }
        else
        {
            text.text = "Недостаточно Глюкозы";
            ClearSelection();
        }
    }

    public void BuildTower()
    {
        if (GameManager.Glukoza >= 10)
        {
            if (selectedNodeA == null) return;
            GameObject newTower = Instantiate(towerPrefab, selectedNodeA.position, selectedNodeA.rotation);
            newTower.transform.position = selectedNodeA.position;
            ClearSelection();
            surface.BuildNavMesh();
            GameManager.Glukoza -= 10;
        }
        else
        {
            text.text = "Недостаточно Глюкозы";
            ClearSelection();
        }
    }

    void ClearSelection()
    {
        if (selectedNodeA != null) HighlightNode(selectedNodeA, false);
        if (selectedNodeB != null) HighlightNode(selectedNodeB, false);
        selectedNodeA = null;
        selectedNodeB = null;
        buildButton.gameObject.SetActive(false);
        buildTurelbutton.gameObject.SetActive(false);
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