using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWilting : MonoBehaviour
{
    public bool m_isWilted;
    public GameObject m_wiltedSeedling;
    public GameObject m_seedling;

    private void Start()
    {
        m_isWilted = false;
    }

    public void PlantWilted()
    {
        m_seedling.SetActive(false);
        m_wiltedSeedling.SetActive(true);
        m_isWilted = true;
    }

    public void PlantWatered()
    {
        m_seedling.SetActive(true);
        m_wiltedSeedling.SetActive(false);
        m_isWilted = false;
    }
}
