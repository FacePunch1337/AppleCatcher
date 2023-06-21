using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Button restartButton;
    public TMP_Text hp;
    public int maxScore;
    private int currentScore;
    

    private void Start()
    {
        currentScore = int.Parse(hp.text);
        hp.text = maxScore.ToString();


    }

    public void DecreaseScore()
    {
        currentScore--;
       

        if (currentScore <= 0)
        {
            EndGame();
        }
    }

   

    private void EndGame()
    {
        menuPanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        currentScore = maxScore;

        menuPanel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}
