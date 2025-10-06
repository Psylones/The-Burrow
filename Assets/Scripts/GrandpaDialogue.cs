using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Center.Common;


public class GrandpaDialogue : MonoBehaviour
{

    public DialogueG dialogueG;
    public DialogueManager dialogueManager;
    public BoxCollider grandpaCollider;
    public Movement movement; //Bec's script
    public bool InGrandpaRange;
    public bool QuestComplete;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
       grandpaCollider.GetComponent<BoxCollider>();
        InGrandpaRange = false;
        QuestComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(UnityEngine.Collider grandpaCollider)
    {
        if (QuestComplete)
        {
            dialogueManager.EndGrandpa(dialogueG);
        }
        if (!QuestComplete && !dialogueManager.HasSpokenBefore)
        {
            dialogueManager.StartGrandpa(dialogueG);
        }
       
        
    }
}
