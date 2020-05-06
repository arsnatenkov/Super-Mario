using System.Linq;
using UnityEngine;

/// <summary>
/// Класс для управления двигающимся монстром
/// </summary>
public class MoveableMonster : Monster
{
    [SerializeField] private float speed = 2.0F;
    private Bullet bullet;
    public AudioClip enterSound;
    private SpriteRenderer sprite;
    private Vector3 direction;

    /// <summary>
    /// Метод, который выполняется в самом начале
    /// </summary>
    protected override void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    /// <summary>
    /// Метод, который выполняется каждый кадр
    /// </summary>
    protected override void Update()
    {
        Move();
    }

    /// <summary>
    /// Метод, выполняющийся на старте
    /// </summary>
    protected override void Start()
    {
        direction = transform.right;
    }

    /// <summary>
    /// Метод, в котором показывается,что двигающийся монстр умирает, если на него приземлится
    /// </summary>
    /// <param name="collider"></param>
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5F) ReceiveDamage();
            else
            {
                AudioSource.PlayClipAtPoint(enterSound, transform.position);
                unit.ReceiveDamage();
            }
        }
    }

    /// <summary>
    /// Метод движения монстра
    /// </summary>
    private void Move()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.5F,
                0.1F);

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F;
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}