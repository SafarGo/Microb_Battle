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

    // Вызывайте этот метод при появлении нового препятствия
    public void UpdateNavMesh()
    {
        surface.BuildNavMesh();  // Перестраивает NavMesh
    }
}