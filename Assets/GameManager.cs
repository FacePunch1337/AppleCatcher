using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject appleSpawner;
    public GameObject box;
    public Button restartButton;
    public TMP_Text scoreTxt;
    public TMP_Text hpTxt;
    public TMP_Text bestScoreTxt;

    public int maxHPScore;
    private int hp;
    private int score;
    private int bestScore;

    private void Start()
    {
        hp = int.Parse(hpTxt.text);
        hpTxt.text = maxHPScore.ToString();
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreTxt.text = bestScore.ToString();
    }

    private void Update()
    {
        if (hpTxt.text == "0")
        {
            EndGame();
        }
        else if (hpTxt.text != "0")
        {
            hp--;
        }
    }



    private void EndGame()
    {
        menuPanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Restart";
        appleSpawner.SetActive(false);

        int currentScore = int.Parse(scoreTxt.text);
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreTxt.text = bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void PlayOrRestartGame()
    {
        hpTxt.text = maxHPScore.ToString();
        scoreTxt.text = "0";
        menuPanel.gameObject.SetActive(false);
        appleSpawner.SetActive(true);
        box.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
