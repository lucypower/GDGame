using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text m_textCounter;
    private int m_score;

    private void Start()
    {
        //m_score = 0;
        m_textCounter.text = "Score : " + m_score;
    }

    public void AddScore(int amount) // something here not working?
    {
        m_score += amount;
        m_textCounter.text = "Score : " + m_score;
    }
}
