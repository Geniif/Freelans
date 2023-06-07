using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageUI : MonoBehaviour
{
    public TextLanguage textLanguage;

    public LocalizationManager localizationManager;

    public TextBall textBall;
    public TextHeart textHeart;
    public TextCookie textCookie;

    public GameObject bgLanguageEng;
    public GameObject bgLanguageUkr;
    public GameObject bgLanguageDe;
    public GameObject bgLanguageFra;

    public Button btnLeft;
    public Button btnRight;

    private void Start()
    {
        if (PlayerPrefs.GetString("Language") == "Eng")
        {
            bgLanguageEng.SetActive(true);
            StartCoroutine(textCookie.FileText("textCookieEng.txt"));
            StartCoroutine(textHeart.FileText("textHeartEng.txt"));
            textBall.wordDisplay.text = "TOUCH ME";
            localizationManager.Eng();
            textCookie.SwapLangEng();
            textHeart.SwapLangEng();
        }
        else if (PlayerPrefs.GetString("Language") == "Ukr")
        {
            bgLanguageUkr.SetActive(true);
            StartCoroutine(textCookie.FileText("textCookieUkr.txt"));
            StartCoroutine(textHeart.FileText("textHeartUkr.txt"));
            textBall.wordDisplay.text = "ТОРКНИСЬ МЕНЕ";
            localizationManager.Ukr();
            textHeart.SwapLangUkr();
            textCookie.SwapLangUkr();
        }
        else if (PlayerPrefs.GetString("Language") == "De")
        {
            bgLanguageDe.SetActive(true);
            StartCoroutine(textCookie.FileText("textCookieDe.txt"));
            StartCoroutine(textHeart.FileText("textHeartDe.txt"));
            textBall.wordDisplay.text = "BERÜHRE MICH";
            localizationManager.De();
            textHeart.SwapLangDe();
            textCookie.SwapLangDe();
        }
        else if (PlayerPrefs.GetString("Language") == "Fra")
        {
            bgLanguageFra.SetActive(true);
            StartCoroutine(textCookie.FileText("textCookieFra.txt"));
            StartCoroutine(textHeart.FileText("textHeartFra.txt"));
            textBall.wordDisplay.text = "TOUCHEZ MOI";
            localizationManager.Fra();
            textHeart.SwapLangFra();
            textCookie.SwapLangFra();
        }
        else if (PlayerPrefs.GetString("Language") == "")
        {
            textLanguage.language = "Ukr";
            bgLanguageUkr.SetActive(true);
            StartCoroutine(textBall.FileText("textBallUkr.txt"));
            StartCoroutine(textCookie.FileText("textCookieUkr.txt"));
            StartCoroutine(textHeart.FileText("textHeartUkr.txt"));
            textBall.wordDisplay.text = "ТОРКНИСЬ МЕНЕ";
            localizationManager.Ukr();
            textHeart.SwapLangUkr();
            textCookie.SwapLangUkr();

        }
    }

    public void Left()
    {

        if (bgLanguageEng.activeInHierarchy)
        {
            bgLanguageEng.SetActive(false);
            bgLanguageUkr.SetActive(true);
        }
        else if (bgLanguageUkr.activeInHierarchy)
        {
            bgLanguageUkr.SetActive(false);
            bgLanguageDe.SetActive(true);
        }
        else if (bgLanguageDe.activeInHierarchy)
        {
            btnLeft.GetComponent<Button>().interactable = false;
        }
        else if (bgLanguageFra.activeInHierarchy)
        {
            bgLanguageFra.SetActive(false);
            bgLanguageEng.SetActive(true);
            btnRight.GetComponent<Button>().interactable = true;
        }
    }

    public void Right()
    {
        if (bgLanguageDe.activeInHierarchy)
        {
            bgLanguageDe.SetActive(false);
            bgLanguageUkr.SetActive(true);
            btnLeft.GetComponent<Button>().interactable = true;
        }
        else if (bgLanguageUkr.activeInHierarchy)
        {
            bgLanguageUkr.SetActive(false);
            bgLanguageEng.SetActive(true);
        }
        else if (bgLanguageEng.activeInHierarchy)
        {
            bgLanguageEng.SetActive(false);
            bgLanguageFra.SetActive(true);
        }
        else if (bgLanguageFra.activeInHierarchy)
        {
            btnRight.GetComponent<Button>().interactable = false;
        }
    }
}
