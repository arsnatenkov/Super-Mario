using UnityEngine;

/// <summary>
/// Пространство под уровнем, где герой теряет одну жизнь
/// </summary>
public class DieSpace : MonoBehaviour
{
    public GameObject respawn; //Точка респауна

    /// <summary>
    /// Если герой попадает в эту область, то возвращается на точку спауна
    /// </summary>
    /// <param name="other">Если падает герой, то у него снижается жизнь и он возвращается на точку спауна</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameMetaData.Hearts--;
            other.transform.position = respawn.transform.position;
        }
    }
}