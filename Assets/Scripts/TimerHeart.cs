using UnityEngine;
using System;
using System.IO;
using System.Collections;
using TMPro;

public class TimerHeart : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private UI uiScript;

    private bool isPaused = false; // флаг дл€ отслеживани€ состо€ни€ паузы

    public float timeStart = 86400f; /*24 часа в секундах*/
    public int startStop;

    public int rewardOff;

    private void Start()
    {
        PlayerPrefs.GetInt("RewardOff", 0);

        startStop = PlayerPrefs.GetInt("CountHeart", 0);

        LoadSavedTime();

        if (startStop == 1)
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    public void StartTimer24Hour()
    {
        if (rewardOff == 0)
        {
            startStop = 1;

            PlayerPrefs.SetInt("CountHeart", startStop);

            StartCoroutine(TimerCoroutine());
        }
        else 
        {
            startStop = -1;
        }
         
    }

    public IEnumerator TimerCoroutine()
    {
        while (startStop == 1)
        {
            timeStart -= Time.deltaTime;

            if (timeStart < 0)
            {
                startStop = 0;

                timeStart = 86400f;

                PlayerPrefs.SetInt("CountHeart", startStop);

                gameController.heartCalldown = 0;

                uiScript.bgHeartGameWindow.transform.Find("btnHeart").Find("Text").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
            }

            PlayerPrefs.SetFloat("TimeHeart24Hour1", timeStart);

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
    //    //SaveCurrentTime(); // —охранение текущего времени при выходе из игры

    //    PlayerPrefs.DeleteAll();
    //    PlayerPrefs.Save();
    //}

    private void SaveCurrentTime()
    {
        // ѕолучение текущего времени на устройстве пользовател€
        DateTime currentTime = DateTime.Now;

        // ѕреобразование текущего времени в строку
        string currentTimeString = currentTime.ToString();

        // —охранение текущего времени в PlayerPrefs
        PlayerPrefs.SetString("SavedTimeHeart", currentTimeString);
        PlayerPrefs.Save();

        Debug.Log("“екущее врем€ сохранено: " + currentTimeString);
    }

    private void LoadSavedTime()
    {
        if (startStop == 1)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString();
            DateTime savedDateTimeFact = DateTime.Parse(currentTimeString);

            string savedTime = PlayerPrefs.GetString("SavedTimeHeart", string.Empty);
            if (!string.IsNullOrEmpty(savedTime))
            {
                DateTime savedDateTime = DateTime.Parse(savedTime);
                DateTime newDateTime = savedDateTimeFact.Subtract(savedDateTime.TimeOfDay); // ¬ычитание фактического времени

                TimeSpan timeSpan = newDateTime.TimeOfDay;
                double totalSeconds = timeSpan.TotalSeconds;


                float savedTimer = PlayerPrefs.GetFloat("TimeHeart24Hour1", 86400f);
                savedTimer -= (float)totalSeconds;
                timeStart = savedTimer;

                Debug.Log("1111 " + savedTimer);

                Debug.Log("Ќовое врем€ в секундах: " + totalSeconds);
            }
        }
    }
}