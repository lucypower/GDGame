using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWilting : MonoBehaviour
{
    public bool m_isWilted;
    public GameObject m_wiltedSeedling;
    public GameObject m_seedling;

    Inventory m_inventory;

    private void Awake()
    {
        m_inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

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

        m_inventory.m_score += 50;
    }

    public void PlantDead()
    {
        m_wiltedSeedling.SetActive(false);
        m_isWilted = false;
    }
}
