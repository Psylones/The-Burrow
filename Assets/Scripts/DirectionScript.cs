using UnityEngine;

public class DirectionScript : MonoBehaviour
{


    [SerializeField] float speed = 100;
    [SerializeField] float jumpHeight = 100;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.right * Input.GetAxis("Horizontal") * speed
        * Time.deltaTime;
        moveDirection.y = rb.linearVelocity.y;
        rb.linearVelocity = moveDirection;
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);
    }


    }

