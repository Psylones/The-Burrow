using TMPro;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    [SerializeField] GameObject ObjectZoomed; //the inspected object
    [SerializeField] TextMeshProUGUI InspectText; //appears when player is in object collider saying they can inspect it
    [SerializeField] BoxCollider collide;
    public bool CanBeInspected; //checks if the player is within the object's collider
    public static bool IsInspected; //So this bool can be changed by other scripts without having all the game objects attached
    [SerializeField] string ObjectName; //Name of the object for debug purposes
    [SerializeField] TextMeshProUGUI CloseText; //text saying how to stop inspecting object

    void Start()
    {
        ObjectZoomed.SetActive(false);
        InspectText.enabled = false;
        CanBeInspected = false;
        IsInspected = false;
        CloseText.enabled = false;
    }
    void Update()
    {
        if (CanBeInspected && Input.GetKeyDown(KeyCode.Space))
        {
            Inspecting();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StopInspecting();
        }
    }

    public void OnTriggerEnter(Collider collide)
    {
        CanBeInspected = true;
        InspectText.enabled = true;
    }

    public void OnTriggerExit(Collider collide)
    {
        CanBeInspected = false;
        InspectText.enabled = false;
    }

    public void Inspecting()
    {
        ObjectZoomed.SetActive(true);
        IsInspected = true;
        CloseText.enabled = true;
        InspectText.enabled = false;
        Debug.Log("Inspecting " + ObjectName);
    }

    public void StopInspecting()
    {
        ObjectZoomed.SetActive(false);
        IsInspected = false;
        CloseText.enabled = false;
        InspectText.enabled = true;
        Debug.Log("Not Inspecting " + ObjectName);

    
    }
}
