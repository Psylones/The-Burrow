using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemOther : MonoBehaviour
{
    public BoxCollider GemRadius;
    public TextMeshProUGUI CollectText;
    public Movement Bec;
    [SerializeField] int DigNumber;
    public bool Digging;
    public GameObject inventoryObject;
    public TextMeshProUGUI inventoryCount;
    public static int treasureCollected;

   // [SerializeField] List<GemOther> gems = new List<GemOther>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CollectText.enabled = false;
        Digging = false;
        inventoryObject.SetActive(false);
        inventoryCount.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && Digging)
            {
            Debug.Log("Digging...");

            DigNumber -= Bec.collectionAmount;
           
           
            if (DigNumber <= 0)
            {
                inventoryObject.SetActive(true);
                inventoryCount.enabled = true;
                Destroy(gameObject);
                Destroy(CollectText);
                treasureCollected++;
                inventoryCount.text = treasureCollected.ToString();
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
