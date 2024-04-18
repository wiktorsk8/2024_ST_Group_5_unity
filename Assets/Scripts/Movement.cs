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
        rb.AddForce(movementVector * force, ForceMode.Impulse);    
    }


    void updateInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 currentDirection = new Vector3 (inputX, 0, inputY);

        movementVector = currentDirection.normalized;
    }

}
