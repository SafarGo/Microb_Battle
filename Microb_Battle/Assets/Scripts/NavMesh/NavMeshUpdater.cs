using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUpdater : MonoBehaviour
{
    public NavMeshSurface surface;

    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

    // ��������� ���� ����� ��� ��������� ������ �����������
    public void UpdateNavMesh()
    {
        surface.BuildNavMesh();  // ������������� NavMesh
    }
}