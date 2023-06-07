using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] private GoogleAdMobController googleAdMobController;
    [SerializeField] private GameController gameController;
    [SerializeField] private Animation animationScript;
    [SerializeField] private Sound sound;
    [SerializeField] public Purchaser purchaser;


    [SerializeField] public Sprite gameBall;
    [SerializeField] public Sprite gameBallActive;

    [SerializeField] public Sprite gameCookie;
    [SerializeField] public Sprite gameCookieActive;

    [SerializeField] public Sprite gameHeart;
    [SerializeField] public Sprite gameHeartActive;
    [SerializeField] public Sprite gameHeartActive2;


    [SerializeField] public GameObject bgStartGame;

    [SerializeField] public GameObject bgHeaderPanel;
    [SerializeField] public GameObject bgFooterPanel;

    [SerializeField] public GameObject bgBallGameWindow;

    [SerializeField] public GameObject bgCookiesGameWindow;
    [SerializeField] public GameObject bgClue;

    [SerializeField] public GameObject bgHeartGameWindow;
    [SerializeField] public GameObject bgSetting;

    [SerializeField] public GameObject bgShop;

    [SerializeField] public GameObject bgHeartPrediction;
    [SerializeField] public GameObject bgError;
    [SerializeField] public GameObject bgBuyHeartPrediction;
    [SerializeField] public GameObject bgCookiesPrediction;

    [SerializeField] public GameObject bgSecondPrivacyPolicy;


    [SerializeField] public GameObject bgEnergy;

    [SerializeField] public GameObject bgSystemErrorHeart;

    [SerializeField] public GameObject AllCookies;

    public TextHeart textHeart;
    public TextCookie textCookie;

    public string language;

    public Transform btnGameBall;
    public Transform btnGameCookie;
    public Transform btnGameHeart;
    public Transform btnStart;
    public Transform btnSetting;
    public Transform btnShop;

    public int count;

    private void Start()
    {

        count = PlayerPrefs.GetInt("Confirm", 0);

        if (count == 1)
        {
            bgSecondPrivacyPolicy.SetActive(false);
        }
        else
        {
            bgSecondPrivacyPolicy.SetActive(true);
        }

        gameController.heartCalldown = PlayerPrefs.GetInt("HeartCalldown", 1);

        if(gameController.heartCalldown == 0)
        {
            btnGameHeart.GetComponent<Image>().sprite = gameHeartActive2;
        }
        else 
        {
            btnGameHeart.GetComponent<Image>().sprite = gameHeartActive;
        }

        bgStartGame.SetActive(true);

        btnStart = bgStartGame.transform.Find("btnStart");
        btnStart.GetComponent<Button>().onClick.AddListener(StartGame);

        btnSetting = bgHeaderPanel.transform.Find("btnSetting");
        btnSetting.GetComponent<Button>().onClick.AddListener(Setting);

        /////////////////////////
        btnShop = bgHeaderPanel.transform.Find("btnShop");
        btnShop.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInSetting = bgSetting.transform.Find("btnShop");
        btnShopInSetting.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInError = bgError.transform.Find("btnShop");
        btnShopInError.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInBuyHeartPrediction = bgBuyHeartPrediction.transform.Find("btnShop");
        btnShopInBuyHeartPrediction.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInSetting2 = bgSetting.transform.Find("btnShop").Find("btnShop2");
        btnShopInSetting2.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInError2 = bgError.transform.Find("btnShop").Find("btnShop2");
        btnShopInError2.GetComponent<Button>().onClick.AddListener(Shop);

        Transform btnShopInBuyHeartPrediction2 = bgBuyHeartPrediction.transform.Find("btnShop").Find("btnShop2");
        btnShopInBuyHeartPrediction2.GetComponent<Button>().onClick.AddListener(Shop);
        ////////////////////////

        btnGameBall = bgFooterPanel.transform.Find("btnGameBall");
        btnGameBall.GetComponent<Button>().onClick.AddListener(BtnBall);

        btnGameCookie = bgFooterPanel.transform.Find("btnGameCookie");
        btnGameCookie.GetComponent<Button>().onClick.AddListener(BtnCookie);

        btnGameHeart = bgFooterPanel.transform.Find("btnGameHeart");
        btnGameHeart.GetComponent<Button>().onClick.AddListener(BtnHeart);

        //Transform btnStartClue = bgClue.transform.Find("btnStartClue");
        //btnStartClue.GetComponent<Button>().onClick.AddListener(BtnClue);

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

        Transform btnBackFromError = bgError.transform.Find("btnExit");
        btnBackFromError.GetComponent<Button>().onClick.AddListener(BtnBackFromError);
        
        Transform btnBackFromSystemErrorHeart = bgSystemErrorHeart.transform.Find("btnExit");
        btnBackFromSystemErrorHeart.GetComponent<Button>().onClick.AddListener(BtnBackFromSystemErrorHeart);

        Transform btnBackFromShop = bgShop.transform.Find("Panel").Find("btnExit");
        btnBackFromShop.GetComponent<Button>().onClick.AddListener(BtnBackFromShop);

        Transform btnBackFromSecondPrivacyPolicy = bgSecondPrivacyPolicy.transform.Find("btnExit");
        btnBackFromSecondPrivacyPolicy.GetComponent<Button>().onClick.AddListener(BtnBackFromSecondPrivacyPolicy);

        Transform btnConfirmSecondPrivacyPolicy = bgSecondPrivacyPolicy.transform.Find("btnConfirm");
        btnConfirmSecondPrivacyPolicy.GetComponent<Button>().onClick.AddListener(BtnBackFromSecondPrivacyPolicyConfirm);
    }

    public void BtnBackFromSecondPrivacyPolicy()
    {
        bgSecondPrivacyPolicy.SetActive(false);
    }

    public void BtnBackFromSecondPrivacyPolicyConfirm()
    {
        bgSecondPrivacyPolicy.SetActive(false);
        count = 1;
        PlayerPrefs.SetInt("Confirm", count);
    }

    public void Error()
    {
        bgError.SetActive(true);

        sound.Open();

        btnGameBall.GetComponent<Button>().interactable = false;
        btnGameCookie.GetComponent<Button>().interactable = false;
        btnGameHeart.GetComponent<Button>().interactable = false;
        btnSetting.GetComponent<Button>().interactable = false;
        btnShop.GetComponent<Button>().interactable = false;
    }

    public void SystemErrorHeart()
    {
        bgSystemErrorHeart.SetActive(true);

        sound.Open();

        btnGameBall.GetComponent<Button>().interactable = false;
        btnGameCookie.GetComponent<Button>().interactable = false;
        btnGameHeart.GetComponent<Button>().interactable = false;
        btnSetting.GetComponent<Button>().interactable = false;
        btnShop.GetComponent<Button>().interactable = false;
    }

    private void BtnBackFromSystemErrorHeart()
    {
        bgSystemErrorHeart.SetActive(false);

        sound.Close();

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    //public void BuyHeart()
    //{
    //    bgBuyHeartPrediction.SetActive(false);

    //    bgBallGameWindow.SetActive(false);
    //    bgCookiesGameWindow.SetActive(false);
    //    bgHeartGameWindow.SetActive(true);

    //    btnGameBall.GetComponent<Image>().sprite = gameBall;
    //    btnGameCookie.GetComponent<Image>().sprite = gameCookie;
    //    btnGameHeart.GetComponent<Image>().sprite = gameHeartActive;

    //    btnGameBall.GetComponent<Button>().interactable = true;
    //    btnGameCookie.GetComponent<Button>().interactable = true;
    //    btnGameHeart.GetComponent<Button>().interactable = true;
    //    btnSetting.GetComponent<Button>().interactable = true;
    //    btnShop.GetComponent<Button>().interactable = true;
    //}

    private void Shop()
    {
        bgShop.SetActive(true);

        sound.Open();

        btnGameBall.GetComponent<Button>().interactable = false;
        btnGameCookie.GetComponent<Button>().interactable = false;
        btnGameHeart.GetComponent<Button>().interactable = false;
        btnSetting.GetComponent<Button>().interactable = false;
        btnShop.GetComponent<Button>().interactable = false;

        bgBallGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
        bgCookiesGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
        bgHeartGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);

        if (bgSetting.activeInHierarchy)
        {
            bgSetting.SetActive(false);
        }
        else if (bgError.activeInHierarchy)
        {
            bgError.SetActive(false);
        }
        else if (bgBuyHeartPrediction.activeInHierarchy)
        {
            bgBuyHeartPrediction.SetActive(false);
        }
    }

    private void BtnBackFromShop()
    {
        bgShop.SetActive(false);

        sound.Close();

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;

        bgBallGameWindow.GetComponent<Image>().color = Color.white;
        bgCookiesGameWindow.GetComponent<Image>().color = Color.white;
        bgHeartGameWindow.GetComponent<Image>().color = Color.white;
    }

    private void BtnBackFromError()
    {
        bgError.SetActive(false);

        sound.Close();

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;

        googleAdMobController.ShowInterstitialAd();
    }

    private void BtnCookiePrediction()
    {
        if (gameController.countCookie >= 0)
        {
            bgCookiesPrediction.SetActive(true);

            sound.Open();

            if (animationScript.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animationScript.anim.Rebind(); // Сбросить анимацию
            }

            animationScript.ChangeAnimation("CookiePredictionAnim");

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnSetting.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }

    }

    private void BtnBackFromCookiePrediction()
    {
        bgCookiesPrediction.SetActive(false);

        sound.Close();

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    private void BtnBackFromSetting() 
    {
        sound.Close();

        if (bgBallGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnSetting.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }
        else if (bgCookiesGameWindow.activeInHierarchy)
        {
            bgCookiesGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnSetting.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }
        else if (bgHeartGameWindow.activeInHierarchy)
        {
            bgHeartGameWindow.GetComponent<Image>().color = Color.white;
            bgSetting.SetActive(false);

            btnGameBall.GetComponent<Button>().interactable = true;
            btnGameCookie.GetComponent<Button>().interactable = true;
            btnGameHeart.GetComponent<Button>().interactable = true;
            btnSetting.GetComponent<Button>().interactable = true;
            btnShop.GetComponent<Button>().interactable = true;
        }

    }

    public void HeartPrediction()
    {
        language = PlayerPrefs.GetString("Language");

        if (language == "Eng")
        {
            StartCoroutine(textHeart.FileText("textHeartEng.txt"));
        }
        else if (language == "Ukr")
        {
            StartCoroutine(textHeart.FileText("textHeartUkr.txt"));
        }
        else if (language == "De")
        {
            StartCoroutine(textHeart.FileText("textHeartDe.txt"));
        }
        else if (language == "Fra")
        {
            StartCoroutine(textHeart.FileText("textHeartFra.txt"));
        }

        if (gameController.heartCalldown == -1)
        {
            SystemErrorHeart();
        }
        else
        {

            StartCoroutine(StartMethodAfterDelay());

            if(purchaser.keyHeart == 0)
            {
                bgHeartPrediction.SetActive(true);

                animationScript.ChangeAnimation("HeartClickAnim");
                animationScript.PlayHeartPredictionAnim();

                btnGameBall.GetComponent<Button>().interactable = false;
                btnGameCookie.GetComponent<Button>().interactable = false;
                btnGameHeart.GetComponent<Button>().interactable = false;
                btnSetting.GetComponent<Button>().interactable = false;
                btnShop.GetComponent<Button>().interactable = false;

                gameController.heartCalldown = -1;
            }
            else
            {
                bgHeartPrediction.SetActive(true);

                animationScript.ChangeAnimation("HeartClickAnim");
                animationScript.PlayHeartPredictionAnim();

                btnGameBall.GetComponent<Button>().interactable = false;
                btnGameCookie.GetComponent<Button>().interactable = false;
                btnGameHeart.GetComponent<Button>().interactable = false;
                btnSetting.GetComponent<Button>().interactable = false;
                btnShop.GetComponent<Button>().interactable = false;
            }

        }

        
    }

    private IEnumerator StartMethodAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Задержка в 3 секунды
        sound.Heart();
    }

    private void BtnBackFromHeartPrediction()
    {
        bgHeartPrediction.SetActive(false);

        sound.Close();

        animationScript.ChangeAnimation("HeartAnim");

        btnGameBall.GetComponent<Button>().interactable = true;
        btnGameCookie.GetComponent<Button>().interactable = true;
        btnGameHeart.GetComponent<Button>().interactable = true;
        btnSetting.GetComponent<Button>().interactable = true;
        btnShop.GetComponent<Button>().interactable = true;
    }

    //private void BtnClue()
    //{
    //    bgClue.SetActive(false);
    //}

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

        if(gameController.heartCalldown == 0)
        {
            btnGameHeart.GetComponent<Image>().sprite = gameHeartActive2;
        }
    }

    private void BtnCookie()
    {
        if (PlayerPrefs.GetString("Language") == "Eng")
        {

            textCookie.SwapLangEng();
        }
        else if (PlayerPrefs.GetString("Language") == "Ukr")
        {

            textCookie.SwapLangUkr();
        }
        else if (PlayerPrefs.GetString("Language") == "De")
        {

            textCookie.SwapLangDe();

        }
        else if (PlayerPrefs.GetString("Language") == "Fra")
        {

            textCookie.SwapLangFra();
        }
        else if (PlayerPrefs.GetString("Language") == "")
        {
            
            textCookie.SwapLangUkr();
        }

        if (!bgCookiesGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.SetActive(false);
            bgCookiesGameWindow.SetActive(true);
            bgHeartGameWindow.SetActive(false);

            bgClue.SetActive(true);

            animationScript.PlayBgClueAnim();

            btnGameBall.GetComponent<Image>().sprite = gameBall;
            btnGameCookie.GetComponent<Image>().sprite = gameCookieActive;
            btnGameHeart.GetComponent<Image>().sprite = gameHeart;
        }

        if (gameController.heartCalldown == 0)
        {
            btnGameHeart.GetComponent<Image>().sprite = gameHeartActive2;
        }
    }

    private void BtnHeart()
    {
        if(PlayerPrefs.GetString("Language") == "Eng")
        {

            textHeart.SwapLangEng();
        }
        else if (PlayerPrefs.GetString("Language") == "Ukr")
        {

            textHeart.SwapLangUkr();
        }
        else if (PlayerPrefs.GetString("Language") == "De")
        {

            textHeart.SwapLangDe();

        }
        else if (PlayerPrefs.GetString("Language") == "Fra")
        {

            textHeart.SwapLangFra();
        }
        else if (PlayerPrefs.GetString("Language") == "")
        {
;
            textHeart.SwapLangUkr();
        }

        if (!bgHeartGameWindow.activeInHierarchy)
        {
            if (gameController.heartCalldown == -1)
            {
                bgHeartGameWindow.SetActive(true);


                    animationScript.ChangeAnimation("HeartAnim");

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
            else if(gameController.heartCalldown == 1)
            {
                bgBuyHeartPrediction.SetActive(true);

                animationScript.ChangeAnimation("HeartAnim");

                btnGameBall.GetComponent<Button>().interactable = true;
                btnGameCookie.GetComponent<Button>().interactable = true;
                btnGameHeart.GetComponent<Button>().interactable = true;
                btnSetting.GetComponent<Button>().interactable = true;
                btnShop.GetComponent<Button>().interactable = true;
            }
            else
            {
                bgHeartGameWindow.SetActive(true);

                animationScript.ChangeAnimation("HeartAnim");

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
        }
    }

    private void BtnBackFromBgBuyHeart()
    {
        bgBuyHeartPrediction.SetActive(false);

        sound.Close();

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

        sound.Open();

        if (bgBallGameWindow.activeInHierarchy)
        {
            bgBallGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnSetting.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
        else if (bgCookiesGameWindow.activeInHierarchy)
        {
            bgCookiesGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnSetting.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
        else if (bgHeartGameWindow.activeInHierarchy)
        {
            bgHeartGameWindow.GetComponent<Image>().color = new Color32(32, 6, 34, 255);
            bgSetting.SetActive(true);

            btnGameBall.GetComponent<Button>().interactable = false;
            btnGameCookie.GetComponent<Button>().interactable = false;
            btnGameHeart.GetComponent<Button>().interactable = false;
            btnSetting.GetComponent<Button>().interactable = false;
            btnShop.GetComponent<Button>().interactable = false;
        }
    }
}
