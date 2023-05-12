using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public float timeLeft = 1800.0f; // 30 минут в секундах
    public TextMeshProUGUI txtTimer; // ссылка на UI-элемент Text дл€ отображени€ обратного отсчета

    void Start()
    {
        float savedTime = PlayerPrefs.GetFloat("Time", 1800.0f);
        timeLeft = savedTime;
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
                gameController.txtCountAttemps.text = $"{gameController.countCookie}’";

                txtTimer.gameObject.SetActive(false);
                gameController.txtCountAttemps.gameObject.SetActive(true);
            }

            PlayerPrefs.SetFloat("Time", timeLeft);

            yield return null;
        }
    }
}
