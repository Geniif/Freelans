using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine.Networking;

public class TextHeart : MonoBehaviour
{
    public TextMeshProUGUI wordDisplay;
    public Button selectButton;
    public string[] wordList;

    private void Start()
    {
        selectButton.onClick.AddListener(SelectRandomWord);

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
        StartCoroutine(FileText("textHeartUkr.txt"));
    }

    public void SwapLangDe()
    {
        StartCoroutine(FileText("textHeartDe.txt"));
    }

    public void SwapLangFra()
    {
        StartCoroutine(FileText("textHeartFra.txt"));
    }

    public void SwapLangEng()
    {
        StartCoroutine(FileText("textHeartEng.txt"));
    }
}
