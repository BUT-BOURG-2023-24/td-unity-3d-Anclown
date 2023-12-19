using System.Collections;
using System.Collections.Generic;
using InguzPings;
using UnityEngine;

public class DestroyCubeOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" | collision.gameObject.tag == "PlayerAmmo")
        {
                Destroy(collision.gameObject);
            }
        }       
}
