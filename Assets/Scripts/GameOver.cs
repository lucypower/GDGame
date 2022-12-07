using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject m_gameOverScreen;
    public TMP_Text m_scoreText;
    public TMP_Text m_inputText;
    public string m_name;
    ScoreManager m_scoreManager;
    Inventory m_inventory;

    public GameObject m_player;
    public GameObject m_scoreM;


    private void Awake()
    {
        //m_scoreManager = m_scoreM.GetComponent<ScoreManager>();
        m_inventory = m_player.GetComponent<Inventory>();
    }

    public void GameOverScreen()
    {
        m_gameOverScreen.SetActive(true);
        m_scoreText.text = "Your score is " + m_inventory.m_score;
    }

    public void SetName()
    {
        m_name = m_inputText.text;
        m_scoreManager.AddScore(new Score(m_name, m_inventory.m_score));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
