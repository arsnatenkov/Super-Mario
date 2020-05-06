using UnityEngine;

/// <summary>
/// Класс для работы с пулей
/// </summary>
public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public AudioClip enterSound;

    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    private float speed = 10.0F; //Скорость пули
    private Vector3 direction;

    public Vector3 Direction
    {
        set { direction = value; }
    }

    public Color Color
    {
        set { sprite.color = value; } // Можно изменять цвет пули
    }

    private SpriteRenderer sprite;

    /// <summary>
    /// При запуске создает ссылку на пулю
    /// </summary>
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// Метод, который удаляет пулю со сцены через 1.4F
    /// </summary>
    private void Start()
    {
        AudioSource.PlayClipAtPoint(enterSound, transform.position);
        Destroy(gameObject, 1.4F);
    }

    /// <summary>
    /// Метод, который отвечает за полет пули
    /// </summary>
    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    /// <summary>
    /// Метод, который определяет касание пули с юнитом, которого она может убить
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit
            unit = collider
                .GetComponent<Unit>(); //В данном случае южным Unitом является Monster, который наследуется от Unit

        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject); //Monster удаляется с карты, если его коснулась пуля
        }
    }
}