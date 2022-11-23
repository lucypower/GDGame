using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySeeds : MonoBehaviour
{
    public GameObject m_shopUI;
    Inventory m_inventory;
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
    }

    public void Purchase()
    {
        if (m_inventory.m_gold > 0)
        {
            m_inventory.m_seedCount++;
            m_inventory.m_gold -= 10;
        }
    }
}
