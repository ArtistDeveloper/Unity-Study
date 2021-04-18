using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RequireTest : MonoBehaviour
{
    Rigidbody rgbody;

    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rgbody.AddForce(Vector3.up);
    }
}
