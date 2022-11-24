using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHotbar : MonoBehaviour
{
    public GameObject[] m_active;

    public int m_inventoryNoSelected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetSprites();

            m_inventoryNoSelected = 1;

            m_active[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ResetSprites();

            m_inventoryNoSelected = 2;

            m_active[1].SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ResetSprites();

            m_inventoryNoSelected = 3;

            m_active[2].SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ResetSprites();

            m_inventoryNoSelected = 4;

            m_active[3].SetActive(true);
        }
    }

    public void ResetSprites()
    {
        for (int i = 0; i < m_active.Length; i++)
        {
            m_active[i].SetActive(false);
        }
    }
}
