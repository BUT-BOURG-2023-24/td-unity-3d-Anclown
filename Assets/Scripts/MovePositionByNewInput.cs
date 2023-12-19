using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByNewInput : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpHeight = 5.0f;
    public InputActionReference moveInputRef = null;
    private bool isGrounded = false;
    private Rigidbody rb;
    public Animator animator = null;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        bool jump = Input.GetKeyDown("space");
        UnityEngine.Vector2 inputMovement = moveInputRef.action.ReadValue<UnityEngine.Vector2>();

        transform.position += new UnityEngine.Vector3(inputMovement.x * speed * Time.deltaTime, 0.0f, inputMovement.y * speed * Time.deltaTime);
        animator.SetFloat("Speed", inputMovement.magnitude * speed);
        if (jump && isGrounded)
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpHeight, ForceMode.Impulse);
            animator.SetBool("Isgrounded", isGrounded);
        }
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
