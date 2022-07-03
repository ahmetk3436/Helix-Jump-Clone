using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score,gamePlayed;
    public TextMeshProUGUI scoreText;

    public void GameScore(int ringScore)
    {
        score += ringScore;
        scoreText.text = score.ToString();
    }
    public void RestartGame()
    {
        gamePlayed++;
        if(gamePlayed > 5)
        {
            int random = Random.Range(0, 6);
            SceneManager.LoadScene(random);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
