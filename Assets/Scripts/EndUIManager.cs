using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TMP_Text currentScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //show current score
        currentScoreText.text = "Score: " + GameManager.Instance.GetScore();

    }

}
