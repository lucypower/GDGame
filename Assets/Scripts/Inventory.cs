using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int m_seedCount = 0;
    public int m_cropCount = 0;
    public int m_gold = 50;
    public int m_score = 0;

    public TMP_Text m_goldCounter;
    public TMP_Text m_seedCounter;
    public TMP_Text m_cropCounter;
    public TMP_Text m_scoreCounter;

    private void Update()
    {
        m_goldCounter.text = "Gold : " + m_gold;
        m_seedCounter.text = "Seeds : " + m_seedCount;
        m_cropCounter.text = "Crops : " + m_cropCount;
        m_scoreCounter.text = "Score : " + m_score;
    }
}
