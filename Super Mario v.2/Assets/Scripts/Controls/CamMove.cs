using UnityEngine;

/// <summary>
/// Класс для управления камерой
/// </summary>
public class CamMove : MonoBehaviour
{
    [SerializeField] private float speed = 7.0F; //Скорость камеры
    [SerializeField] private Transform target; //Цель, то есть место куда смотрит камера

    /// <summary>
    /// При запуске программы, если камера находиться не на герои, то она переходит на него
    /// </summary>
    private void Awake()
    {
        if (!target)
        {
            target = FindObjectOfType<Character>().transform;
        }
    }

    /// <summary>
    /// Перемещение камеры, каждый кадр
    /// </summary>
    private void Update()
    {
        Vector3 position = target.position;
        position.z = -10.0F; //Позиция должна отличаться от позиции фона, иначе мы не увидим фон, а увидим пустоту
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}