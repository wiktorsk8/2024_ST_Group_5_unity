using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    public ConfigurableJoint cjoint;
    public Transform target;


    private Quaternion mirrorAnchor;
    void Start()
    {
        this.cjoint = GetComponent<ConfigurableJoint>();
        mirrorAnchor = target.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cjoint.targetRotation = Quaternion.Inverse(target.rotation) * mirrorAnchor;
    }
}
