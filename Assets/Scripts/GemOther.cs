using TMPro;
using UnityEngine;

public class GemOther : MonoBehaviour
{
    public BoxCollider GemRadius;
    public TextMeshProUGUI CollectText;
    public Movement Bec;
    [SerializeField] int DigNumber;
    public bool Digging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

            DigNumber -= Bec.collectionAmount;

            if (DigNumber <= 0)
            {

                Destroy(gameObject);
                Destroy(CollectText);
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
