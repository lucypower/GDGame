using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    public GameObject m_seed;
    public GameObject[] m_growthStages;
    public float m_growthTime;
    private IEnumerator m_coroutine;
    private GrowthStage m_gStage;
    private int m_stageCount;
    private bool m_canGrow;


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

        //if (m_seed.active)
        //{
        //    StartCoroutine(m_coroutine);

        //    if (m_coroutine == null)
        //    {
        //        m_seed.SetActive(false);
        //        m_growthStages[0].SetActive(true);
        //    }
        //}
    }


    private void Update()
    {
        switch (m_gStage)
        {
            case GrowthStage.SEED:
            
                // need to stop it growing to seedling straight away 

                if (m_growthStages[0].activeInHierarchy)
                {                    
                    if (m_canGrow)
                    {
                        m_stageCount = 0;

                        Growing();

                        m_gStage = GrowthStage.SEEDLING;
                    }
                }               

                break;

            case GrowthStage.SEEDLING:

                if (m_canGrow)
                {
                    m_stageCount++;

                    Growing();

                    m_gStage = GrowthStage.CROP;
                }

                break;

            case GrowthStage.CROP:                               

                break;

            default:
                break;
        }
    }


    private enum GrowthStage
    {
        SEED,
        SEEDLING,
        CROP
    };
}
