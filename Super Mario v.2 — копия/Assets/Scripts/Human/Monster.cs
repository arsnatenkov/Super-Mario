using UnityEngine;

/// <summary>
/// Класс для управления монстром
/// </summary>
public class Monster : Unit
{
    /// <summary>
    /// Метод, который нужно прописать, но он ничего не делает
    /// </summary>
    protected virtual void Awake()
    {
    }

    /// <summary>
    /// Метод, который нужно прописать, но он ничего не делает
    /// </summary>
    protected virtual void Start()
    {
    }

    /// <summary>
    /// Метод, который нужно прописать, но он ничего не делает
    /// </summary>
    protected virtual void Update()
    {
    }


    /// <summary>
    /// Метод, который срабатывает, если пуля коснется монстра
    /// </summary>
    /// <param name="collider"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            ReceiveDamage();
        }

        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.ReceiveDamage();
        }
    }
}