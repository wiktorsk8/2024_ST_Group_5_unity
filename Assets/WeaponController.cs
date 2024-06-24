using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public KeyCode zoomKey = KeyCode.Mouse1;
    public Transform standardPosition;
    public Transform zoomPosition;
    public float duration;
    private float time;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(zoomKey))
        {
            transform.position = Vector3.Lerp(transform.position, zoomPosition.position, duration * Time.deltaTime);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, standardPosition.position, duration * Time.deltaTime);
        }

    }
}
