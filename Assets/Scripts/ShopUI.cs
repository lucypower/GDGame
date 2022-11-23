using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject[] m_shopUI;
    public void CloseUI()
    {
        for (int i = 0; i < m_shopUI.Length; i++)
        {
            m_shopUI[i].SetActive(false);
        }
    }
}
