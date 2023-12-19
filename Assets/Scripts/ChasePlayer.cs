using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 5.0f;
    public Rigidbody rb;
    void Start()
    {
        GameObject playergo = GameObject.FindWithTag("Player");
        player = playergo.transform;
    }

    void Update()
    {
        
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            direction.Normalize();

            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
        }

    }
}

