using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject bgGameBall;
    [SerializeField] private TextMeshProUGUI txtAnswerBall;

    private bool YesNo;
    private int countGameBall = 3;

    private void Start()
    {
        Transform btnGameBall = bgGameBall.transform.Find("backgroundBlackBall");
        btnGameBall.GetComponent<Button>().onClick.AddListener(GameBall);
    }

    private void GameBall()
    {
        countGameBall--;
        if (countGameBall == 0)
        {
            Debug.Log("�������");
            countGameBall = 3;
        }

        int count = Random.Range(0, 2);
        if (count == 0)
        {
            YesNo = false;
            txtAnswerBall.text = "���";
        }
        else
        {
            YesNo = true;
            txtAnswerBall.text = "���";
        }
    }
}
