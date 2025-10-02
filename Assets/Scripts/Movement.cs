using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Movement : MonoBehaviour
{
    public bool NotInConversation; //Changes to false when talking to a character so Bec is unable to move when dialogue is on screen
    
   public Animator anim;
    [SerializeField] float speed;
    public Rigidbody rb;
    public GrandpaDialogue grandpa;
    public CreatureDialogue creature;
    public TorchBeforeEnter torchBeforeEnter;
    [SerializeField] List<Gem> gem = new List<Gem>();

    public int collectionAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {
        if (!grandpa.InGrandpaRange && !creature.InCreatureRange && !torchBeforeEnter.GettingDenied)

        {
            NotInConversation = true;

        }

        if (Input.GetKey(KeyCode.D) && NotInConversation || Input.GetKey(KeyCode.RightArrow) && NotInConversation)
        {

            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A) && NotInConversation || Input.GetKey(KeyCode.LeftArrow) && NotInConversation)
        {

            anim.SetBool("IsBackwards", true);
        }
        else
        {
            anim.SetBool("IsBackwards", false);
        }


       
    }

    public void CollectGem(int id)
    {
        gem.RemoveAt(id);
    }

    public void AddGem(Gem e)
    {
        gem.Add(e);
    }


    private void FixedUpdate()
    {
        if (NotInConversation)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 moveDirection = (Vector2.right * horizontal) + (Vector2.up * vertical);
            moveDirection *= speed * Time.deltaTime;

            rb.linearVelocity = moveDirection;
        }
    }

    public void ConversationOver()
    {
        NotInConversation = true;
    }

   
}
