using UnityEngine;

/// <summary>
/// Класс родитель для всех героев и антигероев
/// </summary>
public class Unit : MonoBehaviour
{
    /// <summary>
    /// Метод получения уронв
    /// </summary>
    public virtual void ReceiveDamage()
    {
        Die();
        GameMetaData.Score += 25;
    }

    /// <summary>
    /// Метод смерти
    /// </summary>
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}