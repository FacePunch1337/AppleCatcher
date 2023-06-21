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

    private void Update()
    {

        if (hp.text == "0")
        {
            EndGame();
        }
        else if(hp.text != "0")
        {
            currentScore--;
        }
    }

 

   

    private void EndGame()
    {
        menuPanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Restart";
    }

    public void RestartGame()
    {
        currentScore = maxScore;

        menuPanel.gameObject.SetActive(false);
       

    }
}
