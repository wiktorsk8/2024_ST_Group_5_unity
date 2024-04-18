using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Update is called once per frame
    public Transform target;
    public float offsetZ;

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(target.position.x, transform.position.y, target.position.z + offsetZ);
        transform.position = offset;
    }
}
