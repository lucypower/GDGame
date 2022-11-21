using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    public GameObject m_seed;
    // public int m_seedCount; for future to limit seed buying

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) && collision.CompareTag("Player"))
        {
            m_seed.SetActive(true);
        }
    }
}
