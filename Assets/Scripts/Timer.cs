using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public float timeLeft = 1800.0f; // 30 ����� � ��������
    public TextMeshProUGUI txtTimer; // ������ �� UI-������� Text ��� ����������� ��������� �������

    private bool isPaused = false; // ���� ��� ������������ ��������� �����

    void Start()
    {
        LoadSavedTime();

        //float savedTime = PlayerPrefs.GetFloat("Time", 1800.0f);
        //timeLeft = savedTimer;
        if(gameController.countCookie <= -1)
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    public IEnumerator TimerCoroutine()
    {
        while (gameController.countCookie <= -1)
        {
            txtTimer.gameObject.SetActive(true);
            gameController.txtCountAttemps.gameObject.SetActive(false);

            timeLeft -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60.0f);
            int seconds = Mathf.FloorToInt(timeLeft % 60.0f);
            txtTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timeLeft < 0)
            {
                timeLeft = 1800.0f;

                gameController.countCookie = 3;
                gameController.txtCountAttemps.text = $"{gameController.countCookie}�";

                txtTimer.gameObject.SetActive(false);
                gameController.txtCountAttemps.gameObject.SetActive(true);
            }

            PlayerPrefs.SetFloat("Time", timeLeft);

            yield return null;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;

        if (pauseStatus)
        {
            SaveCurrentTime();
        }
        else
        {
            LoadSavedTime();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            if (isPaused)
            {
                LoadSavedTime();
            }
        }
        else
        {
            if (!isPaused)
            {
                SaveCurrentTime();
            }
        }
    }

    //private void OnApplicationQuit()
    //{
    //    SaveCurrentTime(); // ���������� �������� ������� ��� ������ �� ����
    //}

    private void SaveCurrentTime()
    {
        // ��������� �������� ������� �� ���������� ������������
        DateTime currentTime = DateTime.Now;

        // �������������� �������� ������� � ������
        string currentTimeString = currentTime.ToString();

        // ���������� �������� ������� � PlayerPrefs
        PlayerPrefs.SetString("SavedTime", currentTimeString);
        PlayerPrefs.Save();

        Debug.Log("������� ����� ���������: " + currentTimeString);
    }

    private void LoadSavedTime()
    {
        if (gameController.countCookie <= -1)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString();
            DateTime savedDateTimeFact = DateTime.Parse(currentTimeString);

            string savedTime = PlayerPrefs.GetString("SavedTime", string.Empty);
            if (!string.IsNullOrEmpty(savedTime))
            {
                DateTime savedDateTime = DateTime.Parse(savedTime);
                DateTime newDateTime = savedDateTimeFact.Subtract(savedDateTime.TimeOfDay); // ��������� ������������ �������

                TimeSpan timeSpan = newDateTime.TimeOfDay;
                double totalSeconds = timeSpan.TotalSeconds;


                float savedTimer = PlayerPrefs.GetFloat("Time", 1800.0f);
                savedTimer -= (float)totalSeconds;
                timeLeft = savedTimer;

                Debug.Log("1111 " + savedTimer);

                Debug.Log("����� ����� � ��������: " + totalSeconds);
            }
        }
    }
}
