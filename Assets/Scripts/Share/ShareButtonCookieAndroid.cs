//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class ShareButtonCookieAndroid : MonoBehaviour
//{
//    public TextCookie textCookie;

//    public string message;

//    public void Share()
//    {
//        message = textCookie.wordDisplay.text;

//        StartCoroutine(TakeScreenshotAndShare());
//    }

//    private IEnumerator TakeScreenshotAndShare()
//    {
//        yield return new WaitForEndOfFrame();

//        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
//        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
//        ss.Apply();

//        string fileName = "shared_img.png";

//        // Создаем путь к папке кэша файлов
//        string cacheFolderPath;
//        if (Application.isEditor)
//        {
//            cacheFolderPath = Application.temporaryCachePath;
//        }
//        else
//        {
//            cacheFolderPath = Path.Combine(Application.persistentDataPath, "cache");
//            Directory.CreateDirectory(cacheFolderPath);
//        }

//        string filePath = Path.Combine(cacheFolderPath, fileName);
//        File.WriteAllBytes(filePath, ss.EncodeToPNG());

//        // Освобождаем память
//        Destroy(ss);

//        new NativeShare().AddFile(filePath)
//            .SetSubject("Cookie")
//            .SetText(message)
//            .SetUrl("https://www.google.com")
//            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
//            .Share();
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System.IO;

public class ShareButtonCookieAndroid : MonoBehaviour
{
    public TextCookie textCookie;

    public string message;

    public void TakeScreenshotAndShare()
    {
        message = textCookie.wordDisplay.text;

        StartCoroutine(CaptureScreenshotAndShare());
    }

    private IEnumerator CaptureScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshotTexture.Apply();

        string fileName = "screenshot.png";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        File.WriteAllBytes(filePath, screenshotTexture.EncodeToPNG());

        // Освобождаем память
        Destroy(screenshotTexture);

        // Открыть диалоговое окно для выбора социальной сети
        //new NativeShare().AddFile(filePath)
        //    .SetSubject("Screenshot")
        //    .SetText("Check out this screenshot!")
        //    .Share();

        new NativeShare().AddFile(filePath)
        .SetSubject("Screenshot").SetText(message).SetUrl("https://play.google.com/store/apps/details?id=com.DefaultCompany.AnswerofFate")
        .Share();
    }
}

