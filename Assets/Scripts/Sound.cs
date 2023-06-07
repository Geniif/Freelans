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
        audioSource.PlayOneShot(clipBall); // �������� ������� ��������� �� �����
    }

    public void Cookie()
    {
        audioSource.PlayOneShot(clipCookie); // �������� ������� ��������� �� �����
    }

    public void Heart()
    {
        audioSource.PlayOneShot(clipHeart); // �������� ������� ��������� �� �����
    }

    public void Open()
    {
        audioSource.PlayOneShot(clipOpen); // �������� ������� ��������� �� �����
    }

    public void Close()
    {
        audioSource.PlayOneShot(clipClose); // �������� ������� ��������� �� �����
    }

    public void Click()
    {
        audioSource.PlayOneShot(clipClick); // �������� ������� ��������� �� �����
    }
}
