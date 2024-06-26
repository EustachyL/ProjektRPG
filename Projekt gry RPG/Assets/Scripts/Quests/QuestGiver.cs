using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
using Assets.Scripts.Player;

public class QuestGiver : MonoBehaviour
{
    public float questGiverId;

    public bool executed = false;
    private double x = 0.0;

    public Quest quest;
    public GameObject player;
    public GameObject newQuestPanel;
    public TMP_Text TitleText;
    public TMP_Text ContentText;
    public TMP_Text BookTitleText;
    public TMP_Text BookContentText;

    public GameObject wall;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject remy;

    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.Log("audioManager jest nullem");
        }
    }


    void ShowPanel()
    {
        newQuestPanel.SetActive(true);
    }

    public void HidePanel()
    {
        newQuestPanel.SetActive(false);
    }

    private IEnumerator ActivatePanelWithDelay()
    {
        ShowPanel();
        yield return new WaitForSeconds(6f);
        HidePanel();
    }

    public void setQuestActive(double id)
    {
        
        Debug.Log("Aktywowano zadanie: " + quest.newQuestInfo);
        Debug.Log(" zadanie z player: " + Player.Instance.quest.id);
        Player.Instance.quest = quest;
        Player.Instance.quest.id = id;
        Debug.Log(" zadanie z player po przypisaniu: " + Player.Instance.quest.id);
        quest.isActive = true;
        TitleText.text = "Nowe zadanie!";
        ContentText.text = Player.Instance.quest.newQuestInfo;
        BookTitleText.text = Player.Instance.quest.title;
        BookContentText.text = Player.Instance.quest.description;
        StartCoroutine(ActivatePanelWithDelay());
        audioManager.PlaySFX(audioManager.newQuest);
        
    }

    public void finishQuest()
    {
        var playerInstance = Player.Instance;
        Debug.Log(" zadanie z player sie konczy: " + playerInstance.quest.id);
        x++;
        Debug.Log("Uko�czono zadanie: " + playerInstance.quest.newQuestInfo);
        audioManager.PlaySFX(audioManager.newQuest); 
        quest.isActive = false;
        playerInstance.AwardExp(quest.ExpReward);
        TitleText.text = "Gratulacje!";
        ContentText.text = "Uko�czy�e� zadanie: " + playerInstance.quest.title + "!";
        BookTitleText.text = "Znajd� zadanie";
        BookContentText.text = "Nie masz obecnie �adnych aktywnych zada�.";
        switch (playerInstance.quest.id)
        {
            case 0:
                BookContentText.text = "Nie masz obecnie �adnych aktywnych zada�. Spr�buj porozmawia� z Krow� Wies�aw�.";
                ActivateDialogueTrigger(10);
                break;
            case 11:
                Debug.Log("Wykonuje sie koniec zadania 11");
                Debug.Log("a to jest " + questGiverId);
                quest = new Quest(12, "�ladem krecich korytarzy", "C� to chyba nie by�a osoba, kt�ra chcia�a dla Ciebie dobrze. Oby nast�pnym razem by�o lepiej. Eksploruj dalej jaskini� i odnajd� prawdziwego sojusznika.", "Odnajd� kreciego in�yniera", 0, 0);
                setQuestActive(12);
                ActivateDialogueTrigger(13);
                wall.SetActive(false);
                remy.transform.position = new Vector3(45, -32, -300);

                break;
            case 12:
                
                break;
            case 13:
                remy.transform.position = new Vector3(45, -32, -300);
                wall.SetActive(true);
                break;
            case 14:
                quest = new Quest(15, "Wybawiciel", "Bat Wuhan przerwa� Bogdanowi w momencie, gdy ten chcia� przekaza� Ci wa�ne informacje. Teraz, gdy nietoperz zosta� pokonany, musisz porozmawia� z Bogdanem i dowiedzie� si�, co wa�nego chcia� Ci powiedzie�.", "Porozmawiaj z Bogdanem", 0, 0);
                setQuestActive(15);
                ActivateDialogueTrigger(16);
                break;
            case 15:
                Debug.Log("QG to jest " + questGiverId);
                wall2.SetActive(false);
                ActivateDialogueTrigger(18);
                playerInstance.quest.id = 17;
                break;
            case 17:
                break;
            case 18:
                Debug.Log("QG18 to jest " + questGiverId);
                wall3.SetActive(false);
                quest = new Quest(19, "Oddanie zguby", "Krowa Wies�awa nadal czeka na swoj� kos�. Musisz odnale�� kos� ukryt� przez Remy'ego i odda� j� Wo�obitce.", "Oddaj kos� Krowie Wo�obitce", 0, 0);
                setQuestActive(19);
                break;
            case 19:
                playerInstance.Inventory.TakeItem("Cow's Scythe");
                BookContentText.text = "Nie masz obecnie �adnych aktywnych zada�. Spr�buj porozmawia� z Mam� Owc�.";
                ActivateDialogueTrigger(20);
                playerInstance.quest.id = 19.5;
                break;
            case 28:
                BookContentText.text = "Nie masz obecnie �adnych aktywnych zada�. Spr�buj porozmawia� z Kameleonem Zakonnikiem.";
                break;
            default:
                BookContentText.text = "Nie masz obecnie �adnych aktywnych zada�. Spr�buj porozmawia� z innym mieszka�cem.";
                break;
        }

        StartCoroutine(ActivatePanelWithDelay());

        // Aktywacja skryptu DialogueTrigger o warto�ci questGiverId r�wnej x

    }

    public void ActivateDialogueTrigger(double id)
    {
        DialogueTrigger[] allTriggers = FindObjectsOfType<DialogueTrigger>();
        foreach (DialogueTrigger trigger in allTriggers)
        {
            if (trigger.questGiverId == id)
            {
                trigger.enabled = true; // Aktywowanie skryptu
                Debug.Log("Aktywowano DialogueTrigger z ID: " + id);
            }
        }
    }
}