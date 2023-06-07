using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System.Collections;

public class TextCookie : MonoBehaviour
{
    public TextMeshProUGUI wordDisplay;
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;
    public Button selectButton4;
    public Button selectButton5;
    public Button selectButton6;
    public Button selectButton7;
    public Button selectButton8;
    public string[] wordList;

    private void Start()
    {
        selectButton1.onClick.AddListener(SelectRandomWord);
        selectButton2.onClick.AddListener(SelectRandomWord);
        selectButton3.onClick.AddListener(SelectRandomWord);
        selectButton4.onClick.AddListener(SelectRandomWord);
        selectButton5.onClick.AddListener(SelectRandomWord);
        selectButton6.onClick.AddListener(SelectRandomWord);
        selectButton7.onClick.AddListener(SelectRandomWord);
        selectButton8.onClick.AddListener(SelectRandomWord);

    }

    private void SelectRandomWord()
    {
        if (wordList.Length > 0)
        {
            int randomIndex = Random.Range(0, wordList.Length);
            string randomWord = RemoveLineNumber(wordList[randomIndex]);
            wordDisplay.text = randomWord;
        }
        else
        {
            Debug.LogWarning("Список слов пуст!");
        }
    }

    private string RemoveLineNumber(string line)
    {
        // Ищем соответствие в строке с помощью регулярного выражения
        Match match = Regex.Match(line, @"^\d+\.\s*(.*)$");

        if (match.Success)
        {
            // Возвращаем текст после точки и возможного отступа
            return match.Groups[1].Value;
        }

        return line;
    }

    public IEnumerator FileText(string name)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, name);

        // Если путь начинается с "jar:", то это означает, что мы работаем с файлом внутри APK
        if (filePath.StartsWith("jar:"))
        {
            // Создаем UnityWebRequest для чтения файла из папки StreamingAssets
            UnityWebRequest www = UnityWebRequest.Get(filePath);

            // Ожидаем завершения загрузки файла
            yield return www.SendWebRequest();

            // Проверяем наличие ошибок при загрузке
            if (www.result == UnityWebRequest.Result.Success)
            {
                // Получаем текст из загруженных данных
                string fileContents = www.downloadHandler.text;

                // Присваиваем строки массиву wordList
                wordList = fileContents.Split('\n');
            }
            else
            {
                Debug.LogError("Ошибка при загрузке файла: " + www.error);
            }
        }
        else
        {
            // Если файл находится за пределами APK (например, в редакторе Unity), то читаем его как обычный текстовый файл
            if (File.Exists(filePath))
            {
                wordList = File.ReadAllLines(filePath);
            }
            else
            {
                Debug.LogError("Файл со списком слов не найден!");
            }
        }

        SelectRandomWord();
    }

    public void SwapLangUkr()
    {
        StartCoroutine(FileText("textCookieUkr.txt"));
    }

    public void SwapLangDe()
    {
        StartCoroutine(FileText("textCookieDe.txt"));
    }

    public void SwapLangFra()
    {
        StartCoroutine(FileText("textCookieFra.txt"));
    }

    public void SwapLangEng()
    {
        StartCoroutine(FileText("textCookieEng.txt"));
    }
}
