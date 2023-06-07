using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    public void Url(string url)
    {
        Application.OpenURL(url);
    }
}
