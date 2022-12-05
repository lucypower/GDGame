using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public RowUI m_rowUI;
    public ScoreManager m_scoreManager;

    private void Start()
    {
        var m_score = m_scoreManager.GetHighScore().ToArray();

        for (int i = 0; i < m_score.Length; i++)
        {
            var m_row = Instantiate(m_rowUI, transform).GetComponent<RowUI>();
            m_row.m_rank.text = (i + 1).ToString();
            m_row.m_name.text = m_score[i].m_name;
            m_row.m_score.text = m_score[i].m_score.ToString();
        }
    }
}
