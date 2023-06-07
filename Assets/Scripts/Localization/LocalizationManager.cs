using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public TextLanguage textLanguage;
    public GameController gameController;

    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("Language", language);
    }

    public void Ukr()
    {
        string language = "Ukr";
        PlayerPrefs.SetString("Language", language);
    }

    public void De()
    {
        string language = "De";
        PlayerPrefs.SetString("Language", language);
    }

    public void Fra()
    {
        string language = "Fra";
        PlayerPrefs.SetString("Language", language);
    }
}
