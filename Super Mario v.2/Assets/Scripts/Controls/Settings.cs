using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Класс для управления настройками
/// </summary>
public class Settings : MonoBehaviour
{
    public bool isFullScreen = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Метод для изменения размера экрана
    /// </summary>
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public AudioMixer am;

    /// <summary>
    /// Метод для управления громкостью звука
    /// </summary>
    /// <param name="sliderValue">Ползунок для управления</param>
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    /// <summary>
    /// Качество
    /// </summary>
    /// <param name="q"> Качество</param>
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    Resolution[] resolutions;
    public Dropdown dropdown;
    private int currResolutionIndex = 0; //Текущее разрешение

    /// <summary>
    /// Метод, который выводит в выпадающий список
    /// все количество размеров экрана
    /// </summary>
    public void Awake()
    {
        dropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        List<string> options = new List<string> (); //Создание списка со строковыми значениями

        for(int i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            string option = resolutions [i].width + " x " + resolutions [i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if(resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currResolutionIndex = i; //То получается его индекс
            }
        }

        dropdown.AddOptions(options); //Добавление элементов в выпадающий список
        dropdown.value = currResolutionIndex; //Выделение пункта с текущим разрешением
        dropdown.RefreshShownValue(); //Обновление отображаемого значения
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(Screen.resolutions[r].width, Screen.resolutions[r].height, isFullScreen);
    }
}