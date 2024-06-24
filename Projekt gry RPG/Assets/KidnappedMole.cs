using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidnappedMole : MonoBehaviour
{
    public GameObject kidnapper;
    public GameObject victim;

    public GameObject quest11;
    private QuestGiver questGiver;

    void Start()
    {
        quest11.SetActive(false);
        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            if (qg.questGiverId == 13)
            {
                questGiver = qg;
                break;
            }
        }

        if (questGiver != null)
        {
            Debug.Log("Znaleziono QuestGiver z ID: " + 13);
        }
        else
        {
            Debug.Log("Nie znaleziono QuestGiver z ID: " + 13);
        }


        Vector3 victimPosition = victim.transform.position; //pozycja porwanego
        victimPosition.z -= 10;
        kidnapper.transform.position = victimPosition;
        kidnapper.SetActive(true);
        if (questGiver != null)
        {
            questGiver.setQuestActive(13);
            Debug.Log("KidnappedMole aktywacja zadania: " + 13);
            questGiver.wall.SetActive(false);
            questGiver.ActivateDialogueTrigger(14);

        }
    }

    float frames = 0;
    void Update()
    {
        
        if(frames < 20)
        {
            Vector3 kidnapperPosition = kidnapper.transform.position;
            kidnapperPosition.z += 0.1f;
            kidnapper.transform.position = kidnapperPosition;
            
        }
        if(frames >= 10 && frames < 20)
        {
            Vector3 victimPosition = victim.transform.position; //pozycja porwanego
            victimPosition.z += 0.1f;
            victim.transform.position = victimPosition;
        }
        if(frames >= 20)
        {
            questGiver.HidePanel();

            victim.SetActive(false);
            kidnapper.SetActive(false);
        }
        frames+=0.1f;
    }
}
