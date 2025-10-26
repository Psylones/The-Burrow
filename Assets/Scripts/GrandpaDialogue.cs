using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrandpaDialogue : MonoBehaviour
{
    [SerializeField] DialogueG dialogueG;
    [SerializeField] DialogueManager dialogueManager;
    public BoxCollider grandpaCollider;
    public bool InGrandpaRange; //is in Grandpa's collider and talking with him
    public static bool QuestComplete; //turns true when 3 treasures are collected

   void Start()
    {
        grandpaCollider.GetComponent<BoxCollider>();
        InGrandpaRange = false;
        QuestComplete = false;
    }
    public void OnTriggerEnter(UnityEngine.Collider grandpaCollider)
    {
        if (!QuestComplete && !dialogueManager.HasSpokenBefore)
        {
            dialogueManager.StartGrandpa(dialogueG); //starts the first round of Grandpa dialogue
        }
       
         if (QuestComplete)
        {
            dialogueManager.EndGrandpa(dialogueG); //starts the second round of Grandpa dialogue
        }
    }
}
