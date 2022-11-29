using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayTimer : MonoBehaviour
{
    [HideInInspector] public float m_arcadeTime = 60;
    [HideInInspector] public float m_timedTime = 300;
    public TMP_Text m_textCounter;


    private void Update()
    {
        if (GamemodeMenu.m_arcade)
        {
            if (m_arcadeTime > 0)
            {
                m_arcadeTime -= Time.deltaTime;

                m_textCounter.text = "" + (int)m_arcadeTime;
            }
            else
            {
                //game over
            }
        }

        if (GamemodeMenu.m_timed)
        {
            if (m_timedTime > 0)
            {
                m_timedTime -= Time.deltaTime;

                m_textCounter.text = "" + (int)m_timedTime;
            }
            else
            {
                //game over
            }
        }


        
    }
}
