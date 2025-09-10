using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GrandpaDialogue : MonoBehaviour
{

    public DialogueG dialogueG;
    public DialogueManager dialogueManager;
    public BoxCollider grandpaCollider;
    public Movement movement; //Bec's script
    public bool InGrandpaRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
       grandpaCollider.GetComponent<BoxCollider>();
        InGrandpaRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(UnityEngine.Collider grandpaCollider)
    {

        dialogueManager.StartGrandpa(dialogueG);
        
        
        
    }
}
