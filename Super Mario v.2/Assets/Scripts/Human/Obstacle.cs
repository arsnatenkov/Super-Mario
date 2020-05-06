using UnityEngine;

/// <summary>
/// Класс для управления монстром-колючкой
/// </summary>
public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Метод, который наносит урон герою от колючки
    /// </summary>
    /// <param name="collider">Главный герой</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }
}