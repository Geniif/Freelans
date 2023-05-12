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
    public AudioSource musicSource; // ������ �� AudioSource ��� ������������ ������
    public Slider volumeSlider; // ������ �� Slider ��� ����������� ���������
    public Toggle musicToggle; // ������ �� Toggle ��� ��������� � ���������� ������

    private float savedVolume = 1f; // ����������� ��������� ������

    public Sprite soundOn;
    public Sprite soundOff;

    void Start()
    {       

        // �������� ����������� ��������� ������ �� PlayerPrefs
        savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = savedVolume;

        // ��������� ���������� �������� ��������� �� Slider
        volumeSlider.value = savedVolume;

        // ��������� ���������� �������� Toggle � ����������� �� ����, ���� �� ������ �������� � ���������� ������� ����
        musicToggle.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;

        // ������ ������������ ������
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
        // ��������� ��������� ������
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

        // ���������� ��������� ������ � PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void ToggleMusic(bool enabled)
    {
        // ��������� ��� ���������� ������
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

        // ���������� ��������� ������ � PlayerPrefs
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();
    }
}
