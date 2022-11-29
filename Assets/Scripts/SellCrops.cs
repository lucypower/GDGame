using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCrops : MonoBehaviour
{
    public GameObject m_shopUI;
    Inventory m_inventory;
    GameplayTimer m_gameplayTimer;
    [SerializeField] GameObject m_player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_shopUI.SetActive(true);
        }
    }

    private void Awake()
    {
        m_inventory = m_player.GetComponent<Inventory>();  
        m_gameplayTimer = GameObject.Find("Canvas").GetComponent<GameplayTimer>();
    }

    public void Sell()
    {
        if (m_inventory.m_cropCount > 0)
        {
            m_inventory.m_cropCount--;
            m_inventory.m_gold += 20;
            m_inventory.m_score += 100;
            m_gameplayTimer.m_arcadeTime++;
        }
    }
}
