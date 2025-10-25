using UnityEngine;

public class Reset : MonoBehaviour
{
    void Update()
    {
        GrandpaDialogue.QuestComplete = false;
        GemOther.treasureCollected = 0;
    }
}
