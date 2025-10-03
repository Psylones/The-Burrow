using TMPro;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    public GameObject ObjectZoomed;
    public TextMeshProUGUI InspectText;
    //private Animator anim;
    public BoxCollider collide;
    public bool CanBeInspected;
    public static bool IsInspected; //So this bool can be changed by other scripts without having all the game objects attached
    [SerializeField] string ObjectName;
    public TextMeshProUGUI CloseText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectZoomed.SetActive(false);
        InspectText.enabled = false;
        CanBeInspected = false;
        IsInspected = false;
        CloseText.enabled = false;
    }

    // Update is called once per frame
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
