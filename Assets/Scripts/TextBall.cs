using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System.Collections;

public class TextBall : MonoBehaviour
{
    public GameController gameController;

    public TextMeshProUGUI wordDisplay;
    public Button selectButton;
    public string[] wordList;



    private void Start()
    {
        selectButton.onClick.AddListener(SelectRandomWord);
    }


    private int currentIndex = 0;
    //баг(через одно слово)
    private void SelectRandomWord()
    {
        //if (wordList.Length > 0)
        //{
        //    int randomIndex = Random.Range(0, wordList.Length);
        //    string randomWord = RemoveLineNumber(wordList[randomIndex]);
        //    wordDisplay.text = randomWord;
        //}
        //else
        //{
        //    Debug.LogWarning("Список слов пуст!");
        //}

        if (wordList.Length > 0)
        {
            string nextWord = RemoveLineNumber(wordList[currentIndex]);
            wordDisplay.text = nextWord;
            currentIndex++;

            if (currentIndex >= wordList.Length)
            {
                currentIndex = 0; // Reset currentIndex to 0 when it reaches the end of the array
            }
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
        StartCoroutine(FileText("textBallUkr.txt"));
    }

    public void SwapLangDe()
    {
        StartCoroutine(FileText("textBallDe.txt"));
    }

    public void SwapLangFra()
    {
        StartCoroutine(FileText("textBallFra.txt"));
    }

    public void SwapLangEng()
    {
        StartCoroutine(FileText("textBallEng.txt"));
    }
}
