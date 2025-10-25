using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemOther : MonoBehaviour
{
    [SerializeField] BoxCollider GemRadius;
    [SerializeField] TextMeshProUGUI CollectText;
    [SerializeField] Movement Bec;
    [SerializeField] int DigNumber;
    public bool Digging;
    public static int treasureCollected;
   
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
