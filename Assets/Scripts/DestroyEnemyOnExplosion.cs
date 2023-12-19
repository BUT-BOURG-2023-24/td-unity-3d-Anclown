using System.Collections;
using System.Collections.Generic;
using InguzPings;
using UnityEngine;

public class DestroyEnemyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider collider)
    {
        if (collider.gameObject.tag == "PlayerAmmo")
        {
                Destroy(gameObject);
                GameManager.Instance.score++;
            }
        }       
        
}
