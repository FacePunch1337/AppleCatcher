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

    private bool isGamePaused = false;
    private bool isMenuOpen = false;
    private bool hasGameStarted = false;
    private void Start()
    {
        hp = int.Parse(hpTxt.text);
        hpTxt.text = maxHPScore.ToString();
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreTxt.text = bestScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else if (!isMenuOpen && hasGameStarted)
            {
                PauseGame();
            }
        }

        if (!isGamePaused)
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
    }

    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        menuPanel.gameObject.SetActive(true);
        restartButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Restart";
        isMenuOpen = true;
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        menuPanel.gameObject.SetActive(false);
        isMenuOpen = false;
    }

    private void EndGame()
    {

        PauseGame();
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
        hasGameStarted = true;
        ResumeGame();
        hpTxt.text = maxHPScore.ToString();
        scoreTxt.text = "0";
        menuPanel.gameObject.SetActive(false);
        appleSpawner.SetActive(true);
        box.SetActive(true);
    }

    public void OpenMenuPanel()
    {
        isMenuOpen = true;
        menuPanel.gameObject.SetActive(true);
        PauseGame();
    }

    public void CloseMenuPanel()
    {
        isMenuOpen = false;
        menuPanel.gameObject.SetActive(false);
        ResumeGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}