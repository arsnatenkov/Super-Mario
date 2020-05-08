using System.Collections;
using Human;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для управления героем
/// </summary>
public class Character : Unit
{
    private LivesBar livesBar; // Поле для хранения сердечек
    [SerializeField] private float speed = 3.0F; //Поле со скоростью героя
    [SerializeField] private float jumpForce = 15.0F; //Поле со скоростью силы прыжка

    private bool isGrounded = false; //Поле для проверки на землю

    private Bullet bullet; //Поле пули

    private CharState State
    {
        get { return (CharState) animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int) value); }
    }

    private Rigidbody2D rigidbody; //Поле для физики героя
    private Animator animator; //Поле для анимации героя
    private SpriteRenderer sprite; //Поле для спрайта героя

    /// <summary>
    /// Метод, в котором происходит все, что должно происходить при начале работы программы с этим классом
    /// </summary>
    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>(); //Находится объект типа LivesBar
        rigidbody = GetComponent<Rigidbody2D>(); //Находится компонент Rigidbody2D
        animator = GetComponent<Animator>(); //Находится компонент анимации
        sprite = GetComponentInChildren<SpriteRenderer>(); //Находятся компоненты спрайты
        bullet = Resources.Load<Bullet>("Bullet"); //Загружается объект пуля
    }

    /// <summary>
    /// При обновлении кадров проверяется стоит ли герой на земле или нет
    /// </summary>
    private void FixedUpdate()
    {
        CheckGround();
    }

    /// <summary>
    /// При обновления кадров проиходят следующие действия
    /// </summary>
    private void Update()
    {
        if (isGrounded) State = CharState.Idle; //Если герой стоит на земле, то запускается анимация стояния на земле
        if (Input.GetButtonDown("Fire1")) Shoot(); // Если нажимается клавиша F, то выстреливает
        if (Input.GetButton("Horizontal")) Run(); //Если нажимают на горизонтальую кнопку, то герой бежит
        if (isGrounded && Input.GetButtonDown("Jump")) Jump(); //Если герой на земле, то он может прыгнуть
        livesBar.Refresh(); //Обновление количества жизней
        if (GameMetaData.Hearts == 0)
        {
            Die();
            SceneManager.LoadScene("Die");
        }
    }

    /// <summary>
    /// Метод для бега
    /// </summary>
    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
        if (isGrounded) State = CharState.Run;
    }

    /// <summary>
    /// Метод для прыжка
    /// </summary>
    private void Jump()
    {
        State = CharState.Jump;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Метод для выстрела
    /// </summary>
    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.8F;
        if (!sprite.flipX)
        {
            position.x += 0.8F;
        }
        else
        {
            position.x -= 0.8F;
        }

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    /// <summary>
    /// Метод для получения урона от монстров
    /// </summary>
    public override void ReceiveDamage()
    {
        GameMetaData.Hearts--;
        GameMetaData.Score -= 50;
        if (GameMetaData.Score < 0)
        {
            GameMetaData.Hearts--;
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Финиширование уровня
    /// </summary>
    /// <param name="other">Дерево с тэгом Finish или пуля</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            StartCoroutine(Wait(1.0F));
        }

        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }

    /// <summary>
    /// Чтобы уровень не завершался, ему делаем задержку
    /// </summary>
    /// <param name="seconds">Длина задержки</param>
    /// <returns>Ожидание на определенное количество секунд</returns>
    private IEnumerator Wait(float seconds)
    {
        if (SceneManager.GetActiveScene().name == "Level_3")
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("FinishGame");
        }
        else
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("Win");
        }
    }


    /// <summary>
    /// Проверка на наличие земли по ногами
    /// </summary>
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }
}


