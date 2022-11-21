using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    private GameObject m_seed;
    public GameObject[] m_growthStages;
    public float m_growthTime;
    private IEnumerator m_coroutine;

    private void Start()
    {
        m_coroutine = PlantGrowthDelay();    
    }

    private IEnumerator PlantGrowthDelay()
    {
        yield return new WaitForSeconds(m_growthTime);
    }

    public void Growing()
    {
        if (m_seed.active)
        {
            StartCoroutine(m_coroutine);

            if (m_coroutine == null)
            {

            }
        }
    }

    private void Update()
    {
        
    }
}
