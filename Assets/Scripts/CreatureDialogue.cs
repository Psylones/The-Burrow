using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CreatureDialogue : MonoBehaviour
{

    [SerializeField] DialogueG dialogueG; //Dialogue script
    [SerializeField] DialogueManagerCreature dialogueManagerCreature; //Creature dialogue manager script
    [SerializeField] BoxCollider creatureCollider;
    public bool InCreatureRange; //turns to true if talking with the Creature

    void Start()
    {
        creatureCollider.GetComponent<BoxCollider>();
        InCreatureRange = false;
        
    }
    public void OnTriggerEnter(UnityEngine.Collider grandpaCollider)
    {
        dialogueManagerCreature.StartCreature(dialogueG);
    }
}
