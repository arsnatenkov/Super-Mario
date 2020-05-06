using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Класс для управления настройками
/// </summary>
public class Settings : MonoBehaviour
{
    bool isFullScreen = true;

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

    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;

    /// <summary>
    /// Метод, который выводит в выпадающий список
    /// все количество размеров экрана
    /// </summary>
    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}