//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Setting : MonoBehaviour
//{
//    public Sprite soundOn;
//    public Sprite soundOff;
//    public bool soundOnOff = true;

//    public GameObject btnSound;

//    private void Start()
//    {
//        btnSound.GetComponent<Image>().sprite = soundOn;
//    }

//    public void onClick()
//    {
//        if (soundOnOff == true)
//        {
//            btnSound.GetComponent<Image>().sprite = soundOff;
//            soundOnOff = false;
//        }
//        else
//        {
//            btnSound.GetComponent<Image>().sprite = soundOn;
//            soundOnOff = true;
//        }
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public AudioSource musicSource; // ссылка на AudioSource для проигрывания музыки
    public Slider volumeSlider; // ссылка на Slider для регулировки громкости
    public Toggle musicToggle; // ссылка на Toggle для включения и выключения музыки

    private float savedVolume = 1f; // сохраненная громкость музыки

    public Sprite soundOn;
    public Sprite soundOff;

    void Start()
    {       

        // загрузка сохраненной громкости музыки из PlayerPrefs
        savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = savedVolume;

        // установка начального значения громкости на Slider
        volumeSlider.value = savedVolume;

        // установка начального значения Toggle в зависимости от того, была ли музыка включена в предыдущем запуске игры
        musicToggle.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;

        // запуск проигрывания музыки
        if (musicToggle.isOn)
        {
            musicSource.Play();
        }

        if (savedVolume == 0f)
        {
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOff;

        }
        else if (savedVolume >= 0.1f)
        {
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOn;
        }
    }

    public void SetVolume(float volume)
    {
        // установка громкости музыки
        musicSource.volume = volume;

        if (volume == 0f)
        {
            musicSource.Pause();
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOff;

        }
        else if(volume >= 0.1f)
        {
            musicSource.Play();
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOn;
        }

        // сохранение громкости музыки в PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void ToggleMusic(bool enabled)
    {
        // включение или выключение музыки
        if (enabled)
        {
            musicSource.Play();
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            musicSource.Pause();
            musicToggle.transform.Find("Background").GetComponent<Image>().sprite = soundOff;
        }

        // сохранение состояния музыки в PlayerPrefs
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();
    }
}
