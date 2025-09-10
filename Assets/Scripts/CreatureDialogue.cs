using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreatureDialogue : MonoBehaviour
{

    public DialogueG dialogueG;
    public DialogueManagerCreature dialogueManagerCreature;
    public BoxCollider creatureCollider;
    public Movement movement; //Bec's script
    public bool InCreatureRange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creatureCollider.GetComponent<BoxCollider>();
        InCreatureRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(UnityEngine.Collider grandpaCollider)
    {

        dialogueManagerCreature.StartCreature(dialogueG);



    }
}
