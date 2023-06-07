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
            Debug.LogWarning("������ ���� ����!");
        }
    }

    private string RemoveLineNumber(string line)
    {
        // ���� ������������ � ������ � ������� ����������� ���������
        Match match = Regex.Match(line, @"^\d+\.\s*(.*)$");

        if (match.Success)
        {
            // ���������� ����� ����� ����� � ���������� �������
            return match.Groups[1].Value;
        }

        return line;
    }

    public IEnumerator FileText(string name)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, name);

        // ���� ���� ���������� � "jar:", �� ��� ��������, ��� �� �������� � ������ ������ APK
        if (filePath.StartsWith("jar:"))
        {
            // ������� UnityWebRequest ��� ������ ����� �� ����� StreamingAssets
            UnityWebRequest www = UnityWebRequest.Get(filePath);

            // ������� ���������� �������� �����
            yield return www.SendWebRequest();

            // ��������� ������� ������ ��� ��������
            if (www.result == UnityWebRequest.Result.Success)
            {
                // �������� ����� �� ����������� ������
                string fileContents = www.downloadHandler.text;

                // ����������� ������ ������� wordList
                wordList = fileContents.Split('\n');
            }
            else
            {
                Debug.LogError("������ ��� �������� �����: " + www.error);
            }
        }
        else
        {
            // ���� ���� ��������� �� ��������� APK (��������, � ��������� Unity), �� ������ ��� ��� ������� ��������� ����
            if (File.Exists(filePath))
            {
                wordList = File.ReadAllLines(filePath);
            }
            else
            {
                Debug.LogError("���� �� ������� ���� �� ������!");
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
