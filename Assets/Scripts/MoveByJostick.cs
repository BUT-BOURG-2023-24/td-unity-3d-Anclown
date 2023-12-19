using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByJostick : MonoBehaviour
{
    public Joystick joystick = null;
    public float speed = 10.0f;
    public Rigidbody body = null;
    public Animator animator = null;

    void Update(){
        Vector2 inputMovement = joystick.Direction;
        body.velocity = new Vector3(inputMovement.x * speed, body.velocity.y, inputMovement.y * speed);
        animator.SetFloat("Speed", inputMovement.magnitude * speed);
    }
}
