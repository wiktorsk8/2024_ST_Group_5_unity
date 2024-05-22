using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    public float positionSpring = 600;
    private ConfigurableJoint cjoint;
    void Start()
    {
        this.cjoint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            cjoint.angularXDrive = setPositionSpring(0, cjoint.angularXDrive);
            cjoint.angularYZDrive = setPositionSpring(0, cjoint.angularYZDrive);
        } else
        {
            cjoint.angularXDrive = setPositionSpring(positionSpring, cjoint.angularXDrive);
            cjoint.angularYZDrive = setPositionSpring(positionSpring, cjoint.angularYZDrive);
        }
    }

    JointDrive setPositionSpring(float value, JointDrive jDrive)
    {
        JointDrive jointDrive = jDrive;
        jointDrive.positionSpring = value;
        return jointDrive;
    }
}
