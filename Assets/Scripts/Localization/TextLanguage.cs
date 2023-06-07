using TMPro;
using UnityEngine;

public class TextLanguage : MonoBehaviour
{
    public TextHeart textHeart;
    public TextCookie textCookie;

    public string language;
    public TextMeshProUGUI text;

    public string textEng;
    public string textUkr;
    public string textDe;
    public string textFra;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (language == "Eng")
        {
            text.text = textEng;
            StartCoroutine(textHeart.FileText("textHeartEng.txt"));
            StartCoroutine(textCookie.FileText("textCookieEng.txt"));
        }
        else if (language == "Ukr")
        {
            text.text = textUkr;
            StartCoroutine(textHeart.FileText("textHeartUkr.txt"));
            StartCoroutine(textCookie.FileText("textCookieUkr.txt"));
        }
        else if (language == "De")
        {
            text.text = textDe;
            StartCoroutine(textHeart.FileText("textHeartDe.txt"));
            StartCoroutine(textCookie.FileText("textCookieDe.txt"));
        }
        else if (language == "Fra")
        {
            text.text = textFra;
            StartCoroutine(textHeart.FileText("textHeartFra.txt"));
            StartCoroutine(textCookie.FileText("textCookieFra.txt"));
        }
        else if (language == "")
        {
            text.text = textUkr;
            StartCoroutine(textHeart.FileText("textHeartUkr.txt"));
            StartCoroutine(textCookie.FileText("textCookieUkr.txt"));
        }
    }

    private void Update()
    {
        language = PlayerPrefs.GetString("Language");

        if (language == "" || language == "Eng")
        {
            text.text = textEng;
        }
        else if (language == "" || language == "Ukr")
        {
            text.text = textUkr;
        }
        else if (language == "" || language == "De")
        {
            text.text = textDe;
        }
        else if (language == "" || language == "Fra")
        {
            text.text = textFra;
        }
    }
}
