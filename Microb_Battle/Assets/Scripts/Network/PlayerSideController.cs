using Photon.Pun;
using System;
using System.Linq;
using UnityEngine;

public class PlayerSideController : MonoBehaviour
{
    public bool isAtaker;
    public static PlayerSideController instance;
    [SerializeField] private PhotonView _photonView;
    private void Start()
    {
        if (!_photonView.IsMine) return;
            Debug.Log(PhotonNetwork.CountOfPlayers);


        if (PhotonNetwork.CountOfPlayers == 1)
        {
                isAtaker = false;
        }
        else
        {
                isAtaker = true;
        }

        if(isAtaker == true)
        {
            if(_photonView.IsMine)
                DisableScriptsByNames("BuildWalls");
        }
    }

    /// <summary>
    /// ��������� ���������� �� ������ �������� �������
    /// </summary>
    public void DisableScriptsByNames(params string[] scriptNames)
    {
        int totalDisabled = 0;

        foreach (string name in scriptNames)
        {
            Type type = FindTypeByName(name);

            if (type == null)
            {
                Debug.LogWarning($"����� '{name}' �� ������.");
                continue;
            }

            UnityEngine.Object[] foundObjects = FindObjectsOfType(type, true);

            foreach (var obj in foundObjects)
            {
                if (obj is Behaviour behaviour)
                {
                    behaviour.enabled = false;
                    totalDisabled++;
                }
            }
        }

        Debug.Log($"��������� {totalDisabled} ���������(��).");
    }

    /// <summary>
    /// ���� ��� �� ����� � ����������� �������
    /// </summary>
    private Type FindTypeByName(string className)
    {
        // ������� ����� � ������ namespace
        Type type = Type.GetType(className);
        if (type != null)
            return type;

        // ����� �� ���� �������
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = asm.GetTypes().FirstOrDefault(t => t.Name == className);
            if (type != null)
                return type;
        }

        return null;
    }
}
