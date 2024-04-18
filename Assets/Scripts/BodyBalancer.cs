using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBalancer : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(0, 1 * force );
        if (rb != null)
        {
              rb.AddForce(vector3, ForceMode.Force);
        }
    }
}
