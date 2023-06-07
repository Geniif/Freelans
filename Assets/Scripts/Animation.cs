using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animation : MonoBehaviour
{
    [SerializeField] private UI uiScript;
    [SerializeField] public Animator anim;

    public string currentAnimation;

    public GameObject btnBall;

    bool active;

    void Start()
    {
        active = true;

        StartCoroutine(StartGameAnim());
    }

    public void ChangeAnimation(string animation)
    {
        anim.Play(animation);
    }


    public void PlayHeartPredictionAnim()
    {

        StartCoroutine(PlayHeartPrediction());
    }

    private IEnumerator PlayHeartPrediction()
    {
        yield return new WaitForSeconds(2.8f);

        ChangeAnimation("HeartPredictionAnim");
        //uiScript.bgHeartGameWindow.transform.Find("btnHeart").Find("Text").GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
    }

    public void PlayBallAnim()
    {

        StartCoroutine(PlayBall());
    }

    private IEnumerator PlayBall()
    {
        ChangeAnimation("BallAnim");
        btnBall.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(3.1f);
        btnBall.gameObject.GetComponent<Button>().interactable = true;
    }

    public void PlayBgClueAnim()
    {
        StartCoroutine(PlayBgClue());
    }

    private IEnumerator PlayBgClue()
    {
        if (active == true)
        {
            ChangeAnimation("CookieAnim");
            active = false;
            yield return new WaitForSeconds(1.25f);
        }
    }

    private IEnumerator StartGameAnim()
    {
        ChangeAnimation("StartWindowAnim");
        yield return new WaitForSeconds(5f);
        
    }
}
