using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections.Generic;
using Unity.AI.Navigation;
using TMPro;
using Photon.Pun;

public class BuildWalls : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject towerPrefab;
    public int Plazmocit_price;
    public int SenStick_price;
    public int Walls_price;
    public LayerMask nodeLayer;  
    public float maxWallLength = 2f;
    public Button buildButton;
    public Button buildTurelbutton;
    public Button BuildSenStick;
    public NavMeshSurface surface;
    public List<Wall> walls = new List<Wall>();
    public List<GameObject> towers = new List<GameObject>();
    private Transform selectedNodeA, selectedNodeB;
    public TMP_Text text;
    public Material Material1, Material2;
    public GameObject error;

    void Start()
    {
        buildButton.interactable = false;
        buildTurelbutton.interactable = false;
        buildButton.onClick.AddListener(BuildWall);
        buildTurelbutton.onClick.AddListener(BuildTower);
        BuildSenStick.onClick.AddListener(BuildStick);
    }

    void Update()
    {
        // Выбор узлов
        if (Input.GetMouseButtonDown(0) && GameManager.isCanSelectTower)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, nodeLayer))
            {
                if (selectedNodeA == null)
                {
                    selectedNodeA = hit.transform;
                    HighlightNode(selectedNodeA, true);
                    buildTurelbutton.interactable = true;
                    BuildSenStick.interactable=true;
                }
                else if (selectedNodeB == null && hit.transform != selectedNodeA)
                {
                    selectedNodeB = hit.transform;
                    HighlightNode(selectedNodeB, true);
                    buildButton.interactable = true;
                    buildTurelbutton.interactable = false;
                    BuildSenStick.interactable = false;
                }
            }
            error.SetActive(false);
            text.text = "";
        }

        // Отмена по ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearSelection();
            error.SetActive(false);
            text.text = "";
        }
    }

    void BuildWall()
    {
        if (GameManager.Glukoza >= Walls_price)
        {
            if (selectedNodeA == null || selectedNodeB == null) return;

            float distance = Vector3.Distance(selectedNodeA.position, selectedNodeB.position);
            if (distance > maxWallLength)
            {
                Debug.Log("Слишком длинная стена!");
                text.text = "Слишком длинная стена!";
                error.SetActive(true);
                ClearSelection();
                return;
            }
            if (WallExists(selectedNodeA, selectedNodeB))
            {
                Debug.Log("Здесь уже есть стена!");
                text.text = "Здесь уже есть стена!";
                error.SetActive(true);
                ClearSelection();
                return;
            }

            GameObject newWall = PhotonNetwork.Instantiate(wallPrefab.name,transform.position,Quaternion.identity);
            Wall wall = newWall.GetComponent<Wall>();
            wall.Setup(selectedNodeA, selectedNodeB);
            walls.Add(wall);
            surface.BuildNavMesh();
            GameManager.Glukoza -= Walls_price;
            ClearSelection();
        }
        else
        {
            text.text = "Недостаточно Глюкозы";
            error.SetActive(true);
            ClearSelection();
        }
    }

    public void BuildTower()
    {
        if (GameManager.Glukoza >= Plazmocit_price)
        {
            if (selectedNodeA == null) return;
            PhotonNetwork.Instantiate(towerPrefab.name, selectedNodeA.position, selectedNodeA.rotation);
            ClearSelection();
            surface.BuildNavMesh();
            GameManager.Glukoza -= Plazmocit_price;
        }
        else
        {
            text.text = "Недостаточно Глюкозы";
            error.SetActive(true);
            ClearSelection();
        }
    }

    public void BuildStick()
    {
        if (GameManager.Glukoza >= SenStick_price)
        {
            if (selectedNodeA == null) return;
            PhotonNetwork.Instantiate("Sennayapalochka", selectedNodeA.position, selectedNodeA.rotation);
            ClearSelection();
            surface.BuildNavMesh();
            GameManager.Glukoza -= SenStick_price;
        }
        else
        {
            text.text = "Недостаточно Глюкозы";
            error.SetActive(true);
            ClearSelection();
        }
    }

    void ClearSelection()
    {
        if (selectedNodeA != null) HighlightNode(selectedNodeA, false);
        if (selectedNodeB != null) HighlightNode(selectedNodeB, false);
        selectedNodeA = null;
        selectedNodeB = null;
        buildButton.interactable = false;
        buildTurelbutton.interactable = false;
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
        node.GetComponent<Renderer>().material =
            highlight ? Material1 : Material2;
    }
}