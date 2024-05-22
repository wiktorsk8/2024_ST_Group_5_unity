using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private Rigidbody rb;
    private Vector3 movementVector;

    public float force = 1;
    public float maxSpeed = 1;
    public float jumpForce = 1;
    public float distToGround;
    public float offset = 0.3f;

    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();

    }

    void FixedUpdate()
    {
        groundTrigger();

        if (isGrounded)
        {
            rb.AddForce(movementVector * force, ForceMode.Impulse);
        }


        if (jumpTrigger())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
      
        limitSpeed();
        Debug.Log(rb.velocity);
    }


    void updateInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 currentDirection = new Vector3 (inputX, 0, inputY);

        movementVector = currentDirection.normalized;
    }

    void limitSpeed()
    {
        if (isGrounded)
        {
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        
    }

    bool jumpTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void groundTrigger()
    {
        Vector3 dupa = new Vector3(0, distToGround, 0);
        isGrounded = Physics.Raycast(transform.position + dupa, -Vector3.up, (distToGround + offset));
    }
}
