using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] private GoogleAdMobController googleAdMobController;
    [SerializeField] private UI ui;
    [SerializeField] private Timer timer;
    [SerializeField] private TimerHeart timerHeart;
    [SerializeField] private TextBall textBall;

    public Sound sound;

    public int heartCalldown;

    [SerializeField] private GameObject bgGameBall;
    [SerializeField] private GameObject bgGameCookie;
    [SerializeField] public TextMeshProUGUI txtAnswerBall;
    [SerializeField] public TextMeshProUGUI txtCountAttemps;

    [SerializeField] private Animation animationScript;

    public TextCookie textCookie;

    private bool YesNo;
    public int countGameBall;

    public int countCookie;

    public int countLang;

    public string language;

    private void Start()
    {

        countGameBall = PlayerPrefs.GetInt("CountGameBall", 3);

        countCookie = LoadCountCookie();
        if (countCookie <= -1)
        {
            countCookie = -1;
            timer.txtTimer.gameObject.SetActive(true);
            txtCountAttemps.gameObject.SetActive(false);
        }
        else
        {
            txtCountAttemps.text = $"{countCookie}X";
        }

        Transform btnGameBall = bgGameBall.transform.Find("backgroundBlackBall");
        btnGameBall.GetComponent<Button>().onClick.AddListener(GameBall);

        Transform btnGameCookie1 = bgGameCookie.transform.Find("AllCookies").Find("cookie1");
        btnGameCookie1.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie2 = bgGameCookie.transform.Find("AllCookies").Find("cookie2");
        btnGameCookie2.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie3 = bgGameCookie.transform.Find("AllCookies").Find("cookie3");
        btnGameCookie3.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie4 = bgGameCookie.transform.Find("AllCookies").Find("cookie4");
        btnGameCookie4.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie5 = bgGameCookie.transform.Find("AllCookies").Find("cookie5");
        btnGameCookie5.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie6 = bgGameCookie.transform.Find("AllCookies").Find("cookie6");
        btnGameCookie6.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie7 = bgGameCookie.transform.Find("AllCookies").Find("cookie7");
        btnGameCookie7.GetComponent<Button>().onClick.AddListener(GameCookie);
        Transform btnGameCookie8 = bgGameCookie.transform.Find("AllCookies").Find("cookie8");
        btnGameCookie8.GetComponent<Button>().onClick.AddListener(GameCookie);

        //Transform allCookies = bgGameCookie.transform.Find("AllCookies");
        //for (int i = 1; i <= 8; i++)
        //{
        //    Transform btnGameCookie = allCookies.Find("cookie" + i);
        //    btnGameCookie.GetComponent<Button>().onClick.AddListener(GameCookie);
        //}

        if (countCookie > 3)
        {
            txtCountAttemps.text = "3X";
        }
    }

    public void SaveCountCookie(int count)
    {
        PlayerPrefs.SetInt("CountCookie", countCookie);
        PlayerPrefs.Save();
    }

    public int LoadCountCookie()
    {
        return PlayerPrefs.GetInt("CountCookie", 3);
    }

    private void GameBall()
    {
        sound.Ball();

        animationScript.PlayBallAnim();

        language = PlayerPrefs.GetString("Language");

        if (language == "Eng")
        {
            StartCoroutine(textBall.FileText("textBallEng.txt"));
        }
        else if (language == "Ukr")
        {
            StartCoroutine(textBall.FileText("textBallUkr.txt"));
        }
        else if (language == "De")
        {
            StartCoroutine(textBall.FileText("textBallDe.txt"));
        }
        else if (language == "Fra")
        {
            StartCoroutine(textBall.FileText("textBallFra.txt"));
        }

        countGameBall--;
        if (countGameBall == 0)
        {
            googleAdMobController.ShowInterstitialAd();
            countGameBall = 3;

        }

        if(countGameBall == 2)
        {
            googleAdMobController.RequestAndLoadInterstitialAd();

        }

        int count = Random.Range(0, 2);
        if (count == 0)
        {
            YesNo = false;
            //txtAnswerBall.text = "Нет";

        }
        else
        {
            YesNo = true;
            //txtAnswerBall.text = "Так";
        }
    }

    private void GameCookie()
    {
        sound.Cookie();

        language = PlayerPrefs.GetString("Language");

        if (language == "Eng")
        {
            StartCoroutine(textCookie.FileText("textCookieEng.txt"));
        }
        else if (language == "Ukr")
        {
            StartCoroutine(textCookie.FileText("textCookieUkr.txt"));
        }
        else if (language == "De")
        {
            StartCoroutine(textCookie.FileText("textCookieDe.txt"));
        }
        else if (language == "Fra")
        {
            StartCoroutine(textCookie.FileText("textCookieFra.txt"));
        }

        if (countCookie <= 3)
        {
            countCookie--;
            txtCountAttemps.text = $"{countCookie}X";
            SaveCountCookie(countCookie);
            if (countCookie == -1)
            {
                StartCoroutine(timer.TimerCoroutine());
                ui.Error();
                googleAdMobController.RequestAndLoadInterstitialAd();
            }
            else if (countCookie < -1)
            {
                txtCountAttemps.gameObject.SetActive(false);
                timer.txtTimer.gameObject.SetActive(true);
                ui.Error();
                googleAdMobController.RequestAndLoadInterstitialAd();
            }
        }
        else if(countCookie > 3)
        {
            txtCountAttemps.text = $"3X";
        }
    }
}
