using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour
{
    public ScoreData m_scores;

    private void Awake()
    {
        //DontDestroyOnLoad(transform.root);

        var json = PlayerPrefs.GetString("scores", "{}");
        m_scores = JsonUtility.FromJson<ScoreData>(json);
        //m_scores = new ScoreData();
    }

    public IEnumerable<Score> GetHighScore()
    {
        return m_scores.m_scores.OrderByDescending(x => x.m_score);
    }

    public void AddScore(Score score)
    {
        m_scores.m_scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(m_scores);
        PlayerPrefs.SetString("scores", json);
    }
}


[System.Serializable]
public class Score
{
    public string m_name;
    public float m_score;

    public Score (string name, float score)
    {
        this.m_name = name;
        this.m_score = score;
    }
}

[System.Serializable]
public class ScoreData
{
    public List<Score> m_scores;

    public ScoreData()
    {
        m_scores = new List<Score>();   
    }
}
