using UnityEngine;



public class Movement : MonoBehaviour
{
    public bool NotInConversation; //Changes to false when talking to a character so Bec is unable to move when dialogue is on screen 
    public Animator anim; //Bec's animator
    [SerializeField] float speed;
    private Rigidbody rb;
    public GrandpaDialogue grandpa;
    public CreatureDialogue creature;
    [SerializeField] bool Grounded; //Test if the character is touching the floor to be able to jump again
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {
        if (!grandpa.InGrandpaRange && !creature.InCreatureRange && !InspectObject.IsInspected)
        {
            NotInConversation = true;
        }
        else
        {
            NotInConversation = false;
        }

        //Running Animations
        if (Input.GetKey(KeyCode.D) && NotInConversation)
        {
            
            anim.SetBool("IsRunning", true);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX; //prevents sliding
            anim.SetBool("IsRunning", false); //Running right
        }
        if (Input.GetKey(KeyCode.A) && NotInConversation)
        {
            anim.SetBool("IsBackwards", true); //Running left
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX; //prevents sliding
            anim.SetBool("IsBackwards", false);
        }
        //Jump Animations
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && NotInConversation && Grounded) 
        {
           anim.SetBool("IsJumpingForward", true); //jumping while moving right
        }
        else
        {  
            anim.SetBool("IsJumpingForward", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && NotInConversation && Grounded)
        {
            anim.SetBool("IsJumpingBackward", true);//jumping while moving left
        }
        else
        {
            anim.SetBool("IsJumpingBackward", false);
        }
        if (Input.GetKey(KeyCode.W) && NotInConversation && Grounded)
        {
            anim.SetBool("IsJumping", true); //Jumping while idle
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
    }

    


    private void FixedUpdate()
    {
        if (NotInConversation) //controls horizontal movement 
        {
            float horizontal = Input.GetAxis("Horizontal");
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
