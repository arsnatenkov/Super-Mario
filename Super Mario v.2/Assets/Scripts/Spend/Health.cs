using UnityEngine;

/// <summary>
/// Класс для сердечек
/// </summary>
public class Health : MonoBehaviour
{
    public AudioClip enterSound;

    /// <summary>
    /// Метод, который определяет, что происходит, если герой касается с сердечка
    /// </summary>
    /// <param name="other">Главный герой</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character)
        {
            if (GameMetaData.Hearts == 5)
            {
                GameMetaData.Score += 100;
            }
            else
            {
                GameMetaData.Hearts++;
            }

            AudioSource.PlayClipAtPoint(enterSound, transform.position);//Звук подбора жизни
            Destroy(gameObject);
        }
    }
}