using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI QuestScore; //the objective UI text in the top right of the screen
    public DialogueManager grandpaManager;
    public GrandpaDialogue grandpaDialogue;

    void Start()
    {
        QuestScore.enabled = false; 
    }
    void Update()
    {
        if (grandpaManager.QuestStart)//if player has spoken to Grandpa and recieved the quest
        {
            QuestScore.enabled = true;
            QuestScore.text = "Objective - Collect Treasure for Grandpa: " + GemOther.treasureCollected.ToString() + "/3";
        }
        if (GemOther.treasureCollected == 3) //when all gems are collected
        {
            QuestScore.text = "Objective - Return to Grandpa";
            GrandpaDialogue.QuestComplete = true;
        }
        if (GemOther.treasureCollected != 3) //if not all gems have been collected
        {
            GrandpaDialogue.QuestComplete = false;
        }
    } 
}
