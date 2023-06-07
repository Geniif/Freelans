using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipBall;
    public AudioClip clipCookie;
    public AudioClip clipHeart;

    public AudioClip clipOpen;
    public AudioClip clipClose;

    public AudioClip clipClick;

    private void Start()
    {
        audioSource.clip = null;
    }

    public void Ball()
    {
        audioSource.PlayOneShot(clipBall); // «аменить текущий аудиоклип на новый
    }

    public void Cookie()
    {
        audioSource.PlayOneShot(clipCookie); // «аменить текущий аудиоклип на новый
    }

    public void Heart()
    {
        audioSource.PlayOneShot(clipHeart); // «аменить текущий аудиоклип на новый
    }

    public void Open()
    {
        audioSource.PlayOneShot(clipOpen); // «аменить текущий аудиоклип на новый
    }

    public void Close()
    {
        audioSource.PlayOneShot(clipClose); // «аменить текущий аудиоклип на новый
    }

    public void Click()
    {
        audioSource.PlayOneShot(clipClick); // «аменить текущий аудиоклип на новый
    }
}
