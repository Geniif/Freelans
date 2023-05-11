using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] private Sprite gameBall;
    [SerializeField] private Sprite gameBallActive;

    [SerializeField] private Sprite gameCookie;
    [SerializeField] private Sprite gameCookieActive;

    [SerializeField] private Sprite gameHeart;
    [SerializeField] private Sprite gameHeartActive;


    [SerializeField] private GameObject bgStartGame;

    [SerializeField] private GameObject bgHeaderPanel;
    [SerializeField] private GameObject bgFooterPanel;

    [SerializeField] private GameObject bgBallGameWindow;

    [SerializeField] private GameObject bgCookiesGameWindow;
    [SerializeField] private GameObject bgClue;

    [SerializeField] private GameObject bgHeartGameWindow;
    [SerializeField] private GameObject bgSetting;

    [SerializeField] private GameObject bgHeartPrediction;
    [SerializeField] private GameObject bgError;
    [SerializeField] private GameObject bgBuyHeartPrediction;
    [SerializeField] private GameObject bgCookiesPrediction;

    [SerializeField] private GameObject bgEnergy;

    [SerializeField] private GameObject AllCookies;

    private Transform btnGameBall;
    private Transform btnGameCookie;
    private Transform btnGameHeart;
    private Transform btnStart;
    private Transform btnSetting;
    private Transform btnShop;

    private void Start()
    {
        btnStart = bgStartGame.transform.Find("btnStart");
        btnStart.GetComponent<Button>().onClick.AddListener(StartGame);

        btnSetting = bgHeaderPanel.transform.Find("btnSetting");
        btnSetting.GetComponent<Button>().onClick.AddListener(Setting);

        btnShop = bgHeaderPanel.transform.Find("btnShop");
        btnShop.GetComponent<Button>().onClick.AddListener(Shop);

        btnGameBall = bgFooterPanel.transform.Find("btnGameBall");
        btnGameBall.GetComponent<Button>().onClick.AddListener(BtnBall);

        btnGameCookie = bgFooterPanel.transform.Find("btnGameCookie");
        btnGameCookie.GetComponent<Button>().onClick.AddListener(BtnCookie);

        btnGameHeart = bgFooterPanel.transform.Find("btnGameHeart");
        btnGameHeart.GetComponent<Button>().onClick.AddListener(BtnHeart);

        Transform btnStartClue = bgClue.transform.Find("btnStartClue");
        btnStartClue.GetComponent<Button>().onClick.AddListener(BtnClue);

        Transform btnHeart = bgHeartGameWindow.transform.Find("btnHeart");
        btnHeart.GetComponent<Button>().onClick.AddListener(HeartPrediction);

        Transform btnBackFromHeartPrediction = bgHeartPrediction.transform.Find("btnExit");
        btnBackFromHeartPrediction.GetComponent<Button>().onClick.AddListener(BtnBackFromHeartPrediction);

        Transform btnBackFromBgBuyHeart = bgBuyHeartPrediction.transform.Find("btnExit");
        btnBackFromBgBuyHeart.GetComponent<Button>().onClick.AddListener(BtnBackFromBgBuyHeart);

        Transform btnBackFromSetting = bgSetting.transform.Find("btnExit");
        btnBackFromSetting.GetComponent<Button>().onClick.AddListener(BtnBackFromSetting);

        for (int i = 0; i < 8; i++)
        {
            AllCookies.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(BtnCookiePrediction);
        }

        Transform btnBackFromCookiePrediction = bgCookiesPrediction.transform.Find("btnExit");
        btnBackFromCookiePrediction.GetComponent<Button>().onClick.AddListener(BtnBackFromCookiePrediction);

    }




    public void BuyHeart()
    {
        bgBuyHeartPrediction.SetActive(false);

        bgBallGameWindow.SetActive(false);
        bgCookiesGameWindow.SetActive(false);
        bgHeartGameWindow.SetActive(true);

        btnGameBall.GetComponent<Image>().sprite = gameBall;
        btnGameCookie.GetComponent<Image>().sprite = gameCookie;
        btnGameHeart.GetComponent<Image>().sprite = gameHeartActive;

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    private void BtnCookiePrediction()
    {
        bgCookiesPrediction.SetActive(true);

        btnGameBall.GetComponent<Button>().interactable = false;
        btnGameCookie.GetComponent<Button>().interactable = false;
        btnGameHeart.GetComponent<Button>().interactable = false;
        btnSetting.GetComponent<Button>().interactable = false;
        btnShop.GetComponent<Button>().interactable = false;
    }

    private void BtnBackFromCookiePrediction()
    {
        bgCookiesPrediction.SetActive(false);

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    private void BtnBackFromSetting() 
    {
        if (bgBallGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }
        else if (bgCookiesGameWindow.activeInHierarchy)
        {
            bgCookiesGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }
        else if (bgHeartGameWindow.activeInHierarchy)
        {
            bgHeartGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }

    }

    private void HeartPrediction()
    {
        bgHeartPrediction.SetActive(true);

        btnGameBall.GetComponent<Button>().interactable = false;
        btnGameCookie.GetComponent<Button>().interactable = false;
        btnGameHeart.GetComponent<Button>().interactable = false;
        btnSetting.GetComponent<Button>().interactable = false;
        btnShop.GetComponent<Button>().interactable = false;
    }

    private void BtnBackFromHeartPrediction()
    {
        bgHeartPrediction.SetActive(false);

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    private void BtnClue()
    {
        bgClue.SetActive(false);
    }

    private void BtnBall()
    {
        if (!bgBallGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.SetActive(true);
            bgCookiesGameWindow.SetActive(false);
            bgHeartGameWindow.SetActive(false);

            btnGameBall.GetComponent<Image>().sprite = gameBallActive;
            btnGameCookie.GetComponent<Image>().sprite = gameCookie;
            btnGameHeart.GetComponent<Image>().sprite = gameHeart;
        }
    }

    private void BtnCookie()
    {
        if (!bgCookiesGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.SetActive(false);
            bgCookiesGameWindow.SetActive(true);
            bgHeartGameWindow.SetActive(false);

            bgClue.SetActive(true);

            btnGameBall.GetComponent<Image>().sprite = gameBall;
            btnGameCookie.GetComponent<Image>().sprite = gameCookieActive;
            btnGameHeart.GetComponent<Image>().sprite = gameHeart;
        }
    }

    private void BtnHeart()
    {
        if (!bgHeartGameWindow.activeInHierarchy)
        {
            bgBuyHeartPrediction.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnSetting.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
    }

    private void BtnBackFromBgBuyHeart()
    {
        bgBuyHeartPrediction.SetActive(false);

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    private void StartGame()
    {
        bgStartGame.SetActive(false);
        bgBallGameWindow.SetActive(true);
        bgHeaderPanel.SetActive(true);
        bgFooterPanel.SetActive(true);
    }


    private void Setting()
    {

        if (bgBallGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
        else if (bgCookiesGameWindow.activeInHierarchy)
        {
            bgCookiesGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
        else if (bgHeartGameWindow.activeInHierarchy)
        {
            bgHeartGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
    }

    private void Shop()
    {
        
    }
}
