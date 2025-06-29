using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour, IDamageable
{
    public Transform nodeA, nodeB;
    public Slider slider;
    public Canvas canvas;
    private GameObject _create_button;
    [SerializeField] private GameObject _fibroplast;
    public float HP { get; set; } = 100f;

    void Start()
    {
        _create_button = GameObject.Find("Fibr");
        _create_button.SetActive(false);
        _create_button.GetComponent<Button>().onClick.AddListener(Create_Fibroplast);
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        slider.value = HP;
        if (HP <= 0)
        {
            GameObject.Find("WallsBuilder").GetComponent<BuildWalls>().walls.Remove(this);
            Die();
        }
    }
    public void Setup(Transform a, Transform b)
    {
        nodeA = a;
        nodeB = b;
        UpdateWallPosition();
    }

    void UpdateWallPosition()
    {
        transform.position = (nodeA.position + nodeB.position) / 2f;
        if (slider != null)
        {
            canvas.transform.localScale = new Vector3(0.0025f, 0.0025f, 0.0025f);
        }
        Vector3 direction = nodeB.position - nodeA.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Rotate(0, 180, 0);
        float length = direction.magnitude;
        transform.localScale = new Vector3(
            0.5f,
            3f,
            length+1.5f
        );
    }

    void Die()
    {
            GameObject.Find("WallsBuilder").GetComponent<BuildWalls>().walls.Remove(this);
            Destroy(gameObject);
    }


    private void OnMouseExit()
    {
        ClearInfo();
        //_create_button.SetActive(false);
    }

    private void OnMouseEnter()
    {
        ShowInfo();
        _create_button.SetActive(true);
    }
    void ShowInfo()
    {
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = $"Коллагеновая стенка\n" +
            $"Преграждает стафилоккокам путь\n" +
            $"Уязвима для клостридий\n" +
            $"HP{HP}";
    }
    

    void ClearInfo()
    {
        TMP_Text text = GameObject.Find("InfoText").GetComponent<TMP_Text>();
        text.text = "";
    }


    public void Create_Fibroplast()
    {
        GameObject instance = Instantiate(_fibroplast, new Vector3(0, 0, 0), transform.rotation);
        instance.GetComponentInChildren<FibroplastController>().SetupTarget(this);
    }
    
}