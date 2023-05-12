using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GoogleAdMobController googleAdMobController;
    [SerializeField] private UI ui;
    [SerializeField] private Timer timer;

    [SerializeField] private GameObject bgGameBall;
    [SerializeField] private GameObject bgGameCookie;
    [SerializeField] private TextMeshProUGUI txtAnswerBall;
    [SerializeField] public TextMeshProUGUI txtCountAttemps;

    private bool YesNo;
    private int countGameBall = 3;

    public int countCookie;

    private void Start()
    {
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
            txtAnswerBall.text = "Нет";
        }
        else
        {
            YesNo = true;
            txtAnswerBall.text = "Так";
        }
    }

    private void GameCookie()
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
}
