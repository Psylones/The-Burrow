using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI QuestScore;
    //[SerializeField] int TreasureCollected;
    public DialogueManager grandpaManager;
    public GrandpaDialogue grandpaDialogue;
    //public GemOther gemOther;
    //[SerializeField] List<GemOther> treasure = new List<GemOther>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //treasure = new List<GemOther>();
        QuestScore.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (grandpaManager.QuestStart)
        {
            QuestScore.enabled = true;
            QuestScore.text = "Objective - Collect Treasure for Grandpa: " + GemOther.treasureCollected.ToString() + "/3";
        }

        if (GemOther.treasureCollected == 3)
        {
            QuestScore.text = "Objective - Return to Grandpa";
            GrandpaDialogue.QuestComplete = true;
           
        }
        if (GemOther.treasureCollected != 3)
        {
            GrandpaDialogue.QuestComplete = false;
        }

    }

  
}
