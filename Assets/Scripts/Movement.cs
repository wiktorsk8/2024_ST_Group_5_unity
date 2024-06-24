using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform orientation;
    
    private Rigidbody rb;
    private Vector3 movementVector;
    public float moveSpeed;
    public float groundDrag;
    public float maxMoveSpeed;

    public bool grounded = true;
    public LayerMask ground;
    public float raycastLen;
    public Transform raycastPos;

    public float jumpForce;
    public float airMultiplier;
    public KeyCode jumpKey = KeyCode.Space;
    public bool canJump; 

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(raycastPos.position, Vector3.down, raycastLen, ground);

        updateInput();
        speedControl();
        if (grounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = 0;
        }

    }

    void FixedUpdate()
    {
        movePlayer();
        jump();
    }


    private void updateInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        canJump = Input.GetKeyDown(jumpKey) && grounded;
    }

    private void movePlayer()
    {
        movementVector = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(movementVector.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > maxMoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * maxMoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
