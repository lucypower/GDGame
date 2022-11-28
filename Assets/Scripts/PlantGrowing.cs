using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    public GameObject[] m_growthStages;

    public float m_growthTime;
    private int m_stageCount;
    public float m_timeToWater;

    private bool m_canGrow;
    private bool m_noActive = true;
    
    private IEnumerator m_coroutine;
    private GrowthStage m_gStage;

    Inventory m_inventory;
    InventoryHotbar m_inventoryHotbar;
    PlantWilting m_plantWilting;


    private void Awake()
    {
        m_inventory = GameObject.Find("Player").GetComponent<Inventory>();
        m_inventoryHotbar = GameObject.Find("Player").GetComponent<InventoryHotbar>();
        m_plantWilting = GetComponent<PlantWilting>();
    }

    private void Start()
    {
        m_canGrow = true;
    }

    private IEnumerator PlantGrowthDelay()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(m_growthTime);
        m_canGrow = true;
    }

    public void Growing()
    {
        Debug.Log("Growing");

        m_growthStages[m_stageCount].gameObject.SetActive(false);
        m_growthStages[m_stageCount + 1].gameObject.SetActive(true);

        m_coroutine = PlantGrowthDelay();
        StartCoroutine(m_coroutine);
        m_canGrow = false;
    }

    private void Update()
    {
        switch (m_gStage)
        {
            case GrowthStage.SEED:
                              
                if (m_canGrow)
                {
                    m_stageCount = 0;

                    Growing();

                    m_gStage = GrowthStage.SEEDLING;
                }          

                break;

            case GrowthStage.SEEDLING:

                if (m_canGrow)
                {
                    RandomValue();

                    if (m_plantWilting.m_isWilted)
                    {
                        if (m_timeToWater > 0)
                        {
                            m_timeToWater -= Time.deltaTime;
                        }
                        else
                        {
                            m_growthStages[m_stageCount].SetActive(false);
                        }
                    }

                    if (m_canGrow && !m_plantWilting.m_isWilted)
                    {
                        m_stageCount++;

                        Growing();

                        m_gStage = GrowthStage.CROP;
                    }
                }                

                break;

            case GrowthStage.CROP:

                break;

            default:
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < m_growthStages.Length; i++)
        {
            if (m_growthStages[i].activeInHierarchy)
            {
                m_noActive = false;
                break;
            }
            else
            {
                m_noActive = true;
            }
        }

        if (m_noActive && m_inventory.m_seedCount > 0 && m_inventoryHotbar.m_inventoryNoSelected == 1)
        {
            if (Input.GetKey(KeyCode.Space) && collision.CompareTag("Player"))
            {
                m_growthStages[0].SetActive(true);
                m_gStage = GrowthStage.SEED;
                m_inventory.m_seedCount--;

                m_coroutine = PlantGrowthDelay();
                StartCoroutine(m_coroutine);
                m_canGrow = false;
            }
        }

        if (m_growthStages[2].activeInHierarchy)
        {
            if(Input.GetKey(KeyCode.Return) && collision.CompareTag("Player"))
            {
                m_growthStages[2].SetActive(false);
                m_inventory.m_cropCount++;
                //m_gStage = GrowthStage.EMPTY;
            }
        }   
        
        if (m_plantWilting.m_isWilted && m_inventoryHotbar.m_inventoryNoSelected == 3)
        {
            if (Input.GetKey(KeyCode.Return) && collision.CompareTag("Player"))
            {
                m_plantWilting.PlantWatered();

                m_coroutine = PlantGrowthDelay();
                StartCoroutine(m_coroutine);
                m_canGrow = false;
            }
        }
    }

    public void RandomValue()
    {
        float random = Random.value;

        if (random <= 0.25f)
        {
            m_plantWilting.PlantWilted();
        }
    }

    private enum GrowthStage
    {
        EMPTY,
        SEED,
        SEEDLING,
        CROP
    };
}
