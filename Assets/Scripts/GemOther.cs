using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemOther : MonoBehaviour
{
    [SerializeField] BoxCollider GemRadius;
    [SerializeField] TextMeshProUGUI CollectText;
    [SerializeField] int DigNumber; //number of clicks for gem to be collected
    public bool Digging; //detects if player is in the gem collider
    public static int treasureCollected; //coounts how many gems have been collected
   
    void Start()
    {
        CollectText.enabled = false;
        Digging = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && Digging)
            {
            Debug.Log("Digging...");
            DigNumber -= 1;
            if (DigNumber <= 0)
            {
                Destroy(gameObject);
                Destroy(CollectText);
                treasureCollected++;
            }
        }
    }

    public void OnTriggerEnter(Collider GemRadius)
    {
        CollectText.enabled = true;
        Digging = true;
    }

    public void OnTriggerExit(Collider GemRadius)
    {
        CollectText.enabled = false;
        Digging = false;
    }

}
