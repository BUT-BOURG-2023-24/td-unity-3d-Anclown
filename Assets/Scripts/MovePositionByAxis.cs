using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.InputSystem;


public class Move : MonoBehaviour
{
    public float jumpHeight = 5.0f;
    public float speed = 5.0f;
    private Rigidbody rb;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        bool jump = Input.GetKeyDown("space");

        UnityEngine.Vector3 moveDirection = new UnityEngine.Vector3(xAxis, 0, zAxis) * speed * Time.deltaTime;
        transform.position += moveDirection;

        if (jump && isGrounded)
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        Debug.Log(jump);
    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (UnityEngine.Vector3.Dot(contact.normal, UnityEngine.Vector3.up) > 0.5)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false; // Set to false when leaving a collision
    }
}
