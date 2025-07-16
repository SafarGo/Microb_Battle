using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoxerControllerUI : MonoBehaviour
{
    public Button buttonLeft;
    public Button buttonRight;
    public Button buttonPunch;
    public Button buttonBlock;

    public Animator animator; // Сюда перетащи компонент Animator боксёра

    public int health = 3;    // ХП игрока
    public int damage = 1;    // Урон игрока
    public bool isBlocking = false; // Открытая переменная для проверки блокировки

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Start()
    {
        // Для onPointerDown и onPointerUp используем EventTrigger
        AddEventTrigger(buttonLeft, EventTriggerType.PointerDown, OnLeftDown);
        AddEventTrigger(buttonLeft, EventTriggerType.PointerUp, OnLeftUp);

        AddEventTrigger(buttonRight, EventTriggerType.PointerDown, OnRightDown);
        AddEventTrigger(buttonRight, EventTriggerType.PointerUp, OnRightUp);

        buttonPunch.onClick.AddListener(OnPunch);

        AddEventTrigger(buttonBlock, EventTriggerType.PointerDown, OnBlockDown);
        AddEventTrigger(buttonBlock, EventTriggerType.PointerUp, OnBlockUp);
    }

    void Update()
    {
        animator.SetBool("isMovingLeft", isMovingLeft);
        animator.SetBool("isMovingRight", isMovingRight);
        animator.SetBool("isBlocking", isBlocking);
        // Анимация удара будет запускаться отдельно
    }

    void OnLeftDown() => isMovingLeft = true;
    void OnLeftUp() => isMovingLeft = false;

    void OnRightDown() => isMovingRight = true;
    void OnRightUp() => isMovingRight = false;

    void OnPunch()
    {
        animator.SetTrigger("Punch");
        // Здесь можно добавить логику удара по противнику
    }

    void OnBlockDown() => isBlocking = true;
    void OnBlockUp() => isBlocking = false;

    // Метод получения урона
    public void TakeDamage(int amount)
    {
        if (isBlocking)
        {
            Debug.Log("Блок активен — урон не проходит!");
            return;
        }

        health -= amount;
        Debug.Log("Получен урон: " + amount + ". Осталось ХП: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Игрок проиграл!");
        // Здесь можно добавить анимацию смерти или перезапуск уровня
    }

    // Вспомогательный метод для добавления событий EventTrigger
    void AddEventTrigger(Button button, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger trigger = button.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = button.gameObject.AddComponent<EventTrigger>();

        var entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener((eventData) => { action(); });
        trigger.triggers.Add(entry);
    }
} 