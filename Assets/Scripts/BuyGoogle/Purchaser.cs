using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Purchaser : MonoBehaviour
{
    public GameController gameController;
    public UI uiScript;
    public TimerHeart timerHeart;

    public int keyHeart;

    public float timeStartDay = 86400f;
    public int startStopDay;

    public float timeStart30Day = 2592000f;
    public int startStop30Day;
    private bool isPaused = false; // флаг дл€ отслеживани€ состо€ни€ паузы


    private void Start()
    {
        keyHeart = PlayerPrefs.GetInt("KeyHeart", 0);

        startStopDay = PlayerPrefs.GetInt("StartStopDay", 0);

        startStop30Day = PlayerPrefs.GetInt("StartStop30Day", 0);

        LoadSavedTime();

        LoadSavedTimeCookie();

        if (startStopDay == 1)
        {
            StartCoroutine(TimerCoroutine());
        }

        if (startStop30Day == 1)
        {
            StartCoroutine(TimerCoroutineCookie());
        }
    }

    public void OnPurchaseComplited(Product product)
    {
        switch (product.definition.id)
        {
            case "com.answeroffate.buydiamond":
                Diamond();
                break;
            case "com.answeroffate.buypremium":
                Premium();
                break;
            case "com.answeroffate.buygold":
                Gold();
                break;
        }
    }

    private void Diamond()
    {
        gameController.countCookie = 1000000000;
        gameController.countGameBall = 1000000000;
        uiScript.bgEnergy.transform.Find("txtTimer").gameObject.SetActive(false);
        uiScript.bgEnergy.transform.Find("txtCountAttempts").gameObject.SetActive(true);
        uiScript.bgEnergy.transform.Find("txtCountAttempts").GetComponent<TextMeshProUGUI>().text = "3X";

        PlayerPrefs.SetInt("CountCookie", gameController.countCookie);
        PlayerPrefs.SetInt("CountGameBall", gameController.countGameBall);

        timerHeart.rewardOff = -1;
        PlayerPrefs.SetInt("RewardOff", timerHeart.rewardOff);

        gameController.heartCalldown = 0;
        PlayerPrefs.SetInt("HeartCalldown", gameController.heartCalldown);

        keyHeart = 1;
        PlayerPrefs.SetInt("KeyHeart", keyHeart);
    }

    private void Premium()
    {
        gameController.heartCalldown = 0;
        PlayerPrefs.SetInt("HeartCalldown", gameController.heartCalldown);

        //keyHeart = 0;
        //PlayerPrefs.SetInt("KeyHeart", keyHeart);

        startStopDay = 1;

        PlayerPrefs.SetInt("StartStopDay", startStopDay);

        StartCoroutine(TimerCoroutine());

        BuyHeart();
    }

    private void Gold()
    {
        gameController.countCookie = 1000000000;
        PlayerPrefs.SetInt("CountCookie", gameController.countCookie);

        timerHeart.rewardOff = -1;
        PlayerPrefs.SetInt("RewardOff", timerHeart.rewardOff);

        gameController.heartCalldown = 0;
        PlayerPrefs.SetInt("HeartCalldown", gameController.heartCalldown);

        keyHeart = 1;
        PlayerPrefs.SetInt("KeyHeart", keyHeart);

        startStop30Day = 1;
        PlayerPrefs.SetInt("StartStop30Day", startStop30Day);

        StartCoroutine(TimerCoroutineCookie());
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;

        if (pauseStatus)
        {
            SaveCurrentTime();
            SaveCurrentTimeCookie();
        }
        else
        {
            LoadSavedTime();
            LoadSavedTimeCookie();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            if (isPaused)
            {
                LoadSavedTime();
                LoadSavedTimeCookie();
            }
        }
        else
        {
            if (!isPaused)
            {
                SaveCurrentTime();
                SaveCurrentTimeCookie();
            }
        }
    }

    //private void OnApplicationQuit()
    //{
    //    SaveCurrentTime(); // —охранение текущего времени при выходе из игры
    //    SaveCurrentTimeCookie();
    //}

    public IEnumerator TimerCoroutine()
    {
        while (startStopDay == 1)
        {
            timeStartDay -= Time.deltaTime;

            if (timeStartDay < 0)
            {
                startStopDay = 0;

                timeStartDay = 86400f;

                keyHeart = 0;

                PlayerPrefs.SetInt("StartStopDay", startStopDay);
            }

            PlayerPrefs.SetFloat("TimeStartDay", timeStartDay);

            yield return null;
        }
    }

    private void SaveCurrentTime()
    {
        // ѕолучение текущего времени на устройстве пользовател€
        DateTime currentTime = DateTime.Now;

        // ѕреобразование текущего времени в строку
        string currentTimeString = currentTime.ToString();

        // —охранение текущего времени в PlayerPrefs
        PlayerPrefs.SetString("SavedTimeHeartDay", currentTimeString);
        PlayerPrefs.Save();

        Debug.Log("“екущее врем€ сохранено: " + currentTimeString);
    }

    private void LoadSavedTime()
    {
        if (startStopDay == 1)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString();
            DateTime savedDateTimeFact = DateTime.Parse(currentTimeString);

            string savedTime = PlayerPrefs.GetString("SavedTimeHeartDay", string.Empty);
            if (!string.IsNullOrEmpty(savedTime))
            {
                DateTime savedDateTime = DateTime.Parse(savedTime);
                DateTime newDateTime = savedDateTimeFact.Subtract(savedDateTime.TimeOfDay); // ¬ычитание фактического времени

                TimeSpan timeSpan = newDateTime.TimeOfDay;
                double totalSeconds = timeSpan.TotalSeconds;


                float savedTimer = PlayerPrefs.GetFloat("TimeStartDay", 86400f);
                savedTimer -= (float)totalSeconds;
                timeStartDay = savedTimer;

                Debug.Log("1111 " + savedTimer);

                Debug.Log("Ќовое врем€ в секундах: " + totalSeconds);
            }
        }
    }

    public void BuyHeart()
    {
        uiScript.bgBuyHeartPrediction.SetActive(false);

        uiScript.bgBallGameWindow.SetActive(false);
        uiScript.bgCookiesGameWindow.SetActive(false);
        uiScript.bgHeartGameWindow.SetActive(true);

        uiScript.btnGameBall.GetComponent<Image>().sprite = uiScript.gameBall;
        uiScript.btnGameCookie.GetComponent<Image>().sprite = uiScript.gameCookie;
        uiScript.btnGameHeart.GetComponent<Image>().sprite = uiScript.gameHeartActive;

        uiScript.btnGameBall.GetComponent<Button>().interactable = true;
        uiScript.btnGameCookie.GetComponent<Button>().interactable = true;
        uiScript.btnGameHeart.GetComponent<Button>().interactable = true;
        uiScript.btnSetting.GetComponent<Button>().interactable = true;
        uiScript.btnShop.GetComponent<Button>().interactable = true;
    }

    public IEnumerator TimerCoroutineCookie()
    {
        while (startStop30Day == 1)
        {
            timeStart30Day -= Time.deltaTime;

            if (timeStart30Day < 0)
            {
                startStop30Day = 0;

                timeStart30Day = 2592000f;

                keyHeart = 0;

                PlayerPrefs.SetInt("StartStop30Day", startStop30Day);
            }

            PlayerPrefs.SetFloat("TimeStart30Day", timeStart30Day);

            yield return null;
        }
    }

    private void SaveCurrentTimeCookie()
    {
        // ѕолучение текущего времени на устройстве пользовател€
        DateTime currentTime = DateTime.Now;

        // ѕреобразование текущего времени в строку
        string currentTimeString = currentTime.ToString();

        // —охранение текущего времени в PlayerPrefs
        PlayerPrefs.SetString("SavedTimeCookieDay", currentTimeString);
        PlayerPrefs.Save();

        Debug.Log("“екущее врем€ сохранено: " + currentTimeString);
    }

    private void LoadSavedTimeCookie()
    {
        if (startStop30Day == 1)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString();
            DateTime savedDateTimeFact = DateTime.Parse(currentTimeString);

            string savedTime = PlayerPrefs.GetString("SavedTimeCookieDay", string.Empty);
            if (!string.IsNullOrEmpty(savedTime))
            {
                DateTime savedDateTime = DateTime.Parse(savedTime);
                DateTime newDateTime = savedDateTimeFact.Subtract(savedDateTime.TimeOfDay); // ¬ычитание фактического времени

                TimeSpan timeSpan = newDateTime.TimeOfDay;
                double totalSeconds = timeSpan.TotalSeconds;


                float savedTimer = PlayerPrefs.GetFloat("TimeStart30Day", 2592000f);
                savedTimer -= (float)totalSeconds;
                timeStart30Day = savedTimer;

                Debug.Log("1111 " + savedTimer);

                Debug.Log("Ќовое врем€ в секундах: " + totalSeconds);
            }
        }
    }
}
