using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Movement : MonoBehaviour
{
    public bool NotInConversation; //Changes to false when talking to a character so Bec is unable to move when dialogue is on screen
    
   public Animator anim;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    public Rigidbody rb;
    public GrandpaDialogue grandpa;
    public CreatureDialogue creature;
    public TorchBeforeEnter torchBeforeEnter;
    [SerializeField] bool Grounded;
    [SerializeField] float jumpHeight;
    [SerializeField] BoxCollider floor;
    
    //public InspectObject inspectObject;
  

    public int collectionAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
    }




    // Update is called once per frame
    void Update()
    {
        if (!grandpa.InGrandpaRange && !creature.InCreatureRange && !torchBeforeEnter.GettingDenied && !InspectObject.IsInspected)

        {
            NotInConversation = true;

        }
        else
        {
            NotInConversation = false;
        }

        if (Input.GetKey(KeyCode.D) && NotInConversation || Input.GetKey(KeyCode.RightArrow) && NotInConversation)
        {
            
            anim.SetBool("IsRunning", true);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A) && NotInConversation || Input.GetKey(KeyCode.LeftArrow) && NotInConversation)
        {

            anim.SetBool("IsBackwards", true);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            anim.SetBool("IsBackwards", false);
        }

       
    }

    


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && Grounded && NotInConversation || Input.GetKey(KeyCode.UpArrow) && Grounded && NotInConversation)
        {
         
           float vertical = Input.GetAxis("Vertical");

           Vector2 moveDirection = (Vector2.up * vertical);
          moveDirection *= jumpSpeed;
          rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
        }

        if (NotInConversation)
        {
            float horizontal = Input.GetAxis("Horizontal");

            float vertical = Input.GetAxis("Vertical");

            Vector2 moveDirection = (Vector2.right * horizontal); 
            moveDirection *= speed * Time.deltaTime;
           

            rb.linearVelocity = moveDirection;
            
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }


    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Debug.Log("on floor");
            Grounded = true;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Debug.Log("off floor");
            Grounded = false;
        }
        else
        {
            return;
        }
    }

    public void ConversationOver()
    {
        NotInConversation = true;
    }

   
}
