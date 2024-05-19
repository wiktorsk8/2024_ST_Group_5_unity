using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSync : MonoBehaviour
{
    public Transform targetLimb;
    private ConfigurableJoint joint;
    void Start()
    {
        this.joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
